# 八方旅人2／歧路旅人II 翻译错误修正补丁

修正游戏内简体中文翻译的错译、歧义、语病、错别字等问题的补丁。

前些天开始玩这个游戏，发现简中翻译的问题有点…多，恰好本作比较MOD友好，于是决定游玩途中顺手把发现的错误记下来，做个修正补丁。

受限于时间精力，我只是普通地玩了一遍游戏，所以无法单从译文文本看出的错译里，我只能发现带配音部分的以及存在明显逻辑问题的，地图对话和NPC情报这种如果译文通顺，即使译错了我也很难注意到，欢迎反馈补充。


## 常见问题

**这个补丁与现存的另一[官中汉化修复补丁](https://github.com/xitieshiz2/Octopath_Traveler2_Localization_Fix)有什么区别？**\
这个补丁专注于更正错误，只修错误不动其他，另一补丁侧重于整体重新润色。

**为什么不引入另一补丁中的名词优化或将修正并入另一补丁？你很喜欢“XX兰多”吗？**\
不不不，不要血口喷人，我才不喜欢，只是如果大幅调整地名，会导致和大部分攻略、资料等玩家产出内容难以对应上，后者对我来说更重要。

**对我来说能看懂的地名更重要，我可以两个补丁一起用吗？**\
很遗憾，译文文本集中存储在一起，MOD无法只对其中个别条目单独做变更，如果同时使用，此补丁内含的全文文本会完全覆盖另一补丁的文本，不过另一补丁的字体变更部分倒是可以正常生效。

**官方繁体中文的质量如何，直接切繁中玩怎么样？**\
我只看了一小部分，体感繁中质量略高于简中、更忠于原文，不过也存在个别简中繁中都译错和简中译对但繁中译错的地方，而且繁中的名词翻译和简中并不一样，用繁中一样会遇到玩家产出内容难以对应上的问题。

**怎么游戏出了这么久之后才做补丁？**\
因、因为我最近才开始玩……

**有其他平台版吗？**\
我的机器没破解，这方面无能为力。


## 下载安装

[下载](https://github.com/Asvel/octopathtraveler2-zhcn-amend/releases)

将文件`Octopath_Traveler2-WindowsNoEditor_zhcn-amend.pak`放到`游戏文件目录\Octopath_Traveler2\Content\Paks\`下即可安装，`游戏文件目录`可通过`Steam库中右键此游戏-管理-浏览本地文件`找到。


## 名词变更

此补丁虽尽量避免改动名词，但仍有个别名词问题较明显只好做出修改，列举如下：

比试习得技能／NPC技能：
* `猛击` → `失明闪光`：原文`フラッシュ`，`フ`不是`ス`，有个单体光魔法已经叫`闪光（閃光）`了，所以加了个`失明`。
* `索取精灵石` → `精灵石调货`：原文`精霊石取り寄せ`，`索取`过于有歧义了（向敌人索取）。
* `钢铁之神` → `盗窃之神`：原文`ゴッド・オブ・スティール`，这里的`スティール`其实是“steal”而非“steel”。
* `射穿心脏` → `一箭穿心`：原文`心を射抜く`，技能效果是施加混乱，所以这里的`心`指的不是器官意义上的心脏。
* `热情` → `电压`：原文`ボルテージ`，日语里“voltage”确实有热情的引申义，但这是个雷魔法。
* `上钩` → `钓起`：原文`釣り上げる`，意思大概是把敌人的行动顺序钓到最前面……

道具：
* `德鲁斯塔鱼` → `德尔斯塔鱼`：原文`デルスタフィッシュ`，`デルスタ`是`新德尔斯塔（ニューデルスタ）`的`德尔斯塔`。

剧情：
* “库国之枪”一家的名字，`鸣·雷` → `雷·鸣`、`雷家` → `鸣家`等等：`メイ家`怎么会是`雷家`，搞错了不但不改还把哥哥的名字`ジン・メイ`硬翻出一个`雷`字来，离谱！

另外可以查看[详细修订内容一览](./amendments.txt)，内含相关文本的使用场景和修订原因。


## License

All OCTOPATH TRAVELER II contents and materials are copyrights of SQUARE ENIX CO., LTD.

Other contents are released to public domain.
