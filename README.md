# FormattableLogging
参数插值日志组件

### Nuget
```
<PackageReference Include="FormattableLogging" Version="1.0.0" />
```

### 功能
传统参数化日志写法：
``` c#
var a = 1;
var b = 2;
this.logger.LogInformation("a = {a}; b = {b}", a, b);
```
FormattableLogging的写法：
``` c#
var a = 1;
var b = 2;
this.logger.LogInformation($"a = {a}; b = {b}");
```
编译后和传统写法一样的参数效果
