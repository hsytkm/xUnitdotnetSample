# xUnit.net Sample

単体テストライブラリのサンプル

Created on 2020/08 (summer vacation)



[NUnit](https://nunit.org/) / [MSTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest) も候補に挙がったが、新しめの github プロジェクトでも採用されていそうだったので [xUnit.net](https://xunit.net/)  を採用した。



## XUnitTestProject

[xUnit.net](https://xunit.net/) の使用例集



## ChainingAssertion.xUnit

xUnit.net に neuecc さん作の [ChainingAssertion](https://github.com/neuecc/ChainingAssertion) (x.Unit用の拡張メソッド群) を導入。

ChainingAssertion により、dynamic による private field アクセスなどが簡単になる。　注）機能が増える訳ではない

NuGetパッケージは 2013年 から更新されていない。



## FluentAssertions.xUnit

xUnit.net に [Fluent Assertions](https://fluentassertions.com/) （テスト期待値を自然に記述できるメソッド拡張のライブラリ）を導入。

neuecc さんの [ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework) でもコレを使ってるようなので、ChainingAssertion よりもコチラが良さそう。

private field への dynamic アクセスには ChainingAssertion を使えば良さそう。



## Reference Website

[xUnit.net](https://xunit.net/)

[Fluent Assertions](https://fluentassertions.com/)

[neuecc/ChainingAssertion](https://github.com/neuecc/ChainingAssertion)

[xUnit.net でユニットテストを始める](https://qiita.com/takutoy/items/84fa6498f0726418825d)

[xBehave.net + Fluent Assertionsを使ったら思いの外便利だった](https://qiita.com/kitamin/items/dbe713efae3066203e94)



