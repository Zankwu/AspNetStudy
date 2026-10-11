# HttpClientEg

一个基于 ASP.NET Core (`net10.0`) 的 `HttpClient` 使用示例项目，演示如何通过 `IHttpClientFactory` 创建 HttpClient，并结合强类型配置选项调用第三方 REST API（以 [Finnhub](https://finnhub.io/) 股票接口为例）。

## 环境要求

- .NET 10 SDK

## 项目结构

```
HttpClientEg/
├── Controllers/
│   └── HomeController.cs      # /  与 /hello 两个示例端点
├── Options/
│   └── FinnHubOptions.cs      # Finnhub 强类型配置（绑定 appsettings 的 FinnApi 节）
├── Services/
│   └── FinnhubService.cs      # 封装 Finnhub 接口调用（行情 / 公司档案）
├── Properties/                # launchSettings 等
├── ProfileMySelf.cs           # 公司档案模型（System.Text.Json 映射）
├── Program.cs                 # 应用入口：服务注册与管道
└── appsettings.json           # 配置
```

## 核心用法

`Program.cs` 中注册：

```csharp
builder.Services.AddHttpClient();                       // 注册 IHttpClientFactory
builder.Services.AddScoped<FinnhubService>();           // 类型化服务
builder.Services.Configure<FinnHubOptions>(
    builder.Configuration.GetSection("FinnApi"));       // 绑定强类型配置
```

`FinnhubService` 通过构造函数注入 `IHttpClientFactory` 与 `IOptions<FinnHubOptions>`，在方法内创建 HttpClient 并发起请求，再反序列化为字典 / 强类型模型。

## 运行

```bash
dotnet restore
dotnet run
```

默认端点：

- `GET /`      —— 查询 AAPL 报价，返回最新成交价
- `GET /hello` —— 查询 AAPL 公司档案

## 配置

Finnhub 的 API Key 通过配置项提供：

```json
{
  "FinnApi": {
    "defalutApiKet": "<YOUR_FINNHUB_API_KEY>"
  }
}
```

建议本地使用用户机密（User Secrets）或环境变量，避免把真实 Key 提交到版本库：

```bash
dotnet user-secrets init
dotnet user-secrets set "FinnApi:defalutApiKet" "<YOUR_FINNHUB_API_KEY>"
```
