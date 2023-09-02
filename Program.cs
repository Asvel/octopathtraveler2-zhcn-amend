using UAssetAPI;
using UAssetAPI.ExportTypes;
using UAssetAPI.PropertyTypes.Objects;
using UAssetAPI.UnrealTypes;

if (args.Length == 0)
{
    Console.WriteLine("用法：\not2-zhcn-amend <Octopath_Traveler2-WindowsNoEditor.pak解包文件所在目录>");
    return;
}
var dataPath = args[0];

var amendments = new Dictionary<string, List<(string, string)>>();
var amendmentLines = File.ReadAllLines(@".\amendments.txt");
for (var i = 0; i < amendmentLines.Length; i++)
{
    var line = amendmentLines[i];
    if (line.Length == 0 || line[0] == '#') continue;
    if (line != "global" && !line.Contains('_')) throw new InvalidDataException();
    foreach (var key in line.Split(','))
    {
        if (!amendments.TryGetValue(key, out var amendment))
        {
            amendment = amendments[key] = new();
        }
        amendment.Add((
            amendmentLines[i + 1].Replace(@"\r", "\r").Replace(@"\n", "\n"),
            amendmentLines[i + 2].Replace(@"\r", "\r").Replace(@"\n", "\n")
        ));
    }
    i += 2;
}

string amend(string key, string text)
{
    foreach (var (src, dst) in amendments["global"])
    {
        text = text.Replace(src, dst);
    }
    if (amendments.TryGetValue(key, out var amendment))
    {
        foreach (var entry in amendment)
        {
            var (src, dst) = entry;
            if (text.Contains('\r'))
            {
                src = src.Replace("\n", "\r\n");
                dst = dst.Replace("\n", "\r\n");
            }
            var textBak = text;
            text = text.Replace(src, dst);
            if (text == textBak) throw new InvalidDataException();
        }
        amendments.Remove(key);
    }
    return text;
}

{
    var assetPath = @"Octopath_Traveler2\Content\GameText\Database\GameTextZH_CN.uasset";
    var asset = new UAsset(Path.Combine(dataPath, assetPath), EngineVersion.VER_UE4_27);
    var data = ((DataTableExport)asset.Exports[0]).Table.Data;
    foreach (var entry in data)
    {
        if (entry.Value.Count != 2) throw new InvalidDataException();
        var property = (TextPropertyData)entry.Value[1];
        if (property.Value == null) continue;
        property.CultureInvariantString.Value = amend(property.Value.Value, property.CultureInvariantString.Value);
    }
    var outputPath = Path.Combine(@".\dist\", assetPath);
    Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
    asset.Write(outputPath);
}

{
    var assetPath = @"Octopath_Traveler2\Content\Talk\Database\TalkData_ZH_CN.uasset";
    var asset = new UAsset(Path.Combine(dataPath, assetPath), EngineVersion.VER_UE4_27);
    var data = ((DataTableExport)asset.Exports[0]).Table.Data;
    foreach (var entry in data)
    {
        if (entry.Value.Count != 6) throw new InvalidDataException();
        var property = (ArrayPropertyData)entry.Value[5];
        if (property.Value == null) continue;
        var value = (FString)property.Value[0].RawValue;
        if (value == null) continue;
        value.Value = amend(entry.Name.Value.Value, value.Value);
    }
    var outputPath = Path.Combine(@".\dist\", assetPath);
    Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
    asset.Write(outputPath);
}

if (amendments.Count != 1) throw new InvalidDataException();
File.WriteAllText(@".\dist\filelist.txt", $"{Path.GetFullPath(@".\dist\Octopath_Traveler2\Content\")}* ../../../Octopath_Traveler2/Content/");
Console.WriteLine($"打包命令：\nUnrealPak Octopath_Traveler2-WindowsNoEditor_zhcn-amend.pak -Create={Path.GetFullPath(@".\dist\filelist.txt")} -compress");
