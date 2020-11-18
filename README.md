<h1 align="center">Welcome to AgileWork 👋</h1>

## 系列文章
[【文章目录】](https://www.cnblogs.com/zypblog/p/13546760.html)

## 介绍
敏捷应用构建平台预期将形成一款可视化低代码快速开发平台，面向业务、企业管理系统定制开发平台和应用平台，包括设计器、应用端。提供业务配置和集成开发能力，用户通过可视化拖拉拽配置式操作即可快速构建出能同时在PC和移动端运行的各类管理系统，对于企业客户的信息系统在管理模式、业务流程、表单界面、数据可视化展示、IoT管控等个性化需求，可以通过设计器，快速的进行个性化配置。并支持企业微信，公众号，钉钉等移动集成，实现用户跨区域移动办公。从而构建企业个性化的行业应用、集成应用和复杂的业务报表。

* Ocelot网关，多个Web应用程序, 每个应用都使用不同的API网关.
* 包含使用IdentityServer4身份认证服务，SSO(单点登陆)应用程序.
* 采用不同类型的数据库: SQL Server、MySql、MongoDB.
* 使用 Redis 做分布式缓存.
* 使用 RabbitMQ 做服务间的消息传递.
* 使用 Docker 来部署&运行所有的服务和应用程序.
* 使用 Elasticsearch & Logstash & Kibana 来存储和可视化日志

## 相关技术
基于领域驱动设计（DDD）的分层模型，底层框架采用 ABP vNext 微服务搭建项目，支持各种主流数据库(SqlServer、MySQL、PostgreSql、Sqlite)接入，接口遵循 RESTful API 接口规范。前端采用React，通过封装后的axios进行数据请求。实际开发中可能涉及到其他插件和组件。
* ABP vNext
* ABP Framework
* .NET Core 3.1
* Docker
* Kubernates
* Kibana
* Elasticsearch
* Nginx
* Redis
* Hangfire
* RabbitMQ
* MySQL
* SqlServer
* MongoDB
* WebApi
* IdentityServer
* EntityFramework Core
* Swagger
* log4net
* MailKit
* axios
* Json
...

## 项目结构
* `_run`
  * `__Open_Browser.ps1` - **打开浏览器**
  * `__Run_All_Service.ps1` - **运行全部项目**
  * `__Run_Docker_Service.ps1` - **运行项目到 Docker**
  * `__Run_Infrastructure.ps1` - **运行 Docker 基础设施**
  * `__Stop_Docker_Service.ps1` - **停止 Docker 项目**
  * `__Stop_Infrastructure.ps1` - **停止 Docker 基础设施**
  * `01_AuthServer.ps1` - **运行授权服务**
  * `02_BackendAdminService.ps1` - **运行后台管理服务**
  * `03_InternalGateway.ps1` - **运行内部网关**
  * `04_BackendAdminGateway.ps1` -**运行后台管理网关**
* `data` - **数据库文件**
* `docs` - **文档文件**
  * `images`
  * `releases`
* `elk` - **ELK 日志配置**
* `logs` - **Docker 项目运行日志**
* `service` - **后台服务**
  * `auth` - **授权**
    * AuthServer.Host - **授权服务**
  * `framework` - **框架**
  * `gateways` - **网关**
    * BackendAdminGateway.Host -**后台管理网关**
    * InternalGateway.Host - **内部网关**
  * `microservices` - **服务**
    * BackendAdminService.Host - **后台管理服务**
  * `modules` - **模块**
    * account - **账户**
    * audit-logging - **日志**
    * backend-admin - **后台**
    * feature-management - **功能**
    * file-management - **文件**
    * identity - **身份认证**
    * identityServer - **认证服务**
    * permissions-management - **权限**
    * setting-management - **设置**
    * tenant-management - **租户**
  * `shared` - **共有**
  * `common.props`
  * `Microservice.sln`
* `.dockerignore`
* `.gitignore`
* `docker-compose.infrastructure.override.yml` - **Docker 基础设施（环境变量、参数）**
* `docker-compose.infrastructure.yml` - **Docker 基础设施**
* `docker-compose.override.yml` - **Docker 项目运行（环境变量、参数）**
* `docker-compose.yml` - **Docker 项目运行**
* `README.md`

## 分层结构
![agilework.jpg](https://github.com/zhang8043/AgileWork/blob/master/docs/images/agilework.jpg)

## 自动化构建CI/CD
![cicd.png](https://github.com/zhang8043/AgileWork/blob/master/docs/images/cicd.png)

## 环境准备

* Docker Desktop
* SQL Server 2015+
* MySQL 5.7
* Redis 5.0+
* RabbitMQ 3.7.11+
* MongoDB 4.0+
* ElasticSearch 6.6+
* Logstash 6.6+
* Kibana 6.6+

## 运行解决方案

### 修改环境配置

数据库连接、Redis、RabbitMQ、ElasticSearch、AuthServer、IdentityServer

* `service/auth/AuthServer.Host/appsettings.json`
* `service/gateways/BackendAdminGateway.Host/appsettings.json`
* `service/gateways/InternalGateway.Host/appsettings.json`
* `service/microservices/BackendAdminService.Host/appsettings.json`

### 打开并构建Visual Studio解决方案

* 在Visual Studio中打开 `service/Microservice.sln` 并构建解决方案.
* 在 `service` 文件夹中运行 `dotnet restore` 命令.

### 创建数据库

**AuthServer 数据库**

* 右键 `AuthServer.Host` 项目,然后点击 `设置为启动项目`.
* 打开 **程序包管理器控制台** (工具 -> NuGet 包管理器 -> 程序包管理器控制台)
* 选择 `AuthServer.Host` 成为 默认项目.
* 执行 `Update-Database` 命令.

**BackendAdminService 数据库**

* 右键 `BackendAdminService.Host` 项目,然后点击 `设置为启动项目`.
* 打开 **程序包管理器控制台** (工具 -> NuGet 包管理器 -> 程序包管理器控制台)
* 选择 `BackendAdminService.Host` 成为 默认项目.
* 执行 `Update-Database` 命令.

### 1、Docker 运行

在 `项目根目录` 下运行 `docker-compose` 命令或使用 `PowerShell` 运行 `_run` 文件夹下的脚本

**运行基础设施**

使用 `PowerShell` 运行 `_run` 文件夹下的 `__Run_Infrastructure.ps1` 脚本或：
```PowerShell
docker-compose -f docker-compose.infrastructure.yml -f docker-compose.infrastructure.override.yml up -d
```

**运行项目**

使用 `PowerShell` 运行 `_run` 文件夹下的 `__Run_Docker_Service.ps1` 脚本或：
```PowerShell
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

### 2、Visual Studio 运行

按以下顺序运行项目(右键单击每个项目设置为启动项目,按Ctrl+F5运行,无需调试):

* AuthServer.Host
* BackendAdminApp.Host
* InternalGateway.Host
* BackendAdminAppGateway.Host

## 所需基础
服务端采用的是.NET Abp vNext微服务架构，需要了解微服务架构和熟悉 C#。

此系列文章会进行不定期的更新，体量很大，实现功能比较复杂，感兴趣的朋友可以跟着看看，本系统是采用ABP vNext微服务开发的敏捷应用构建平台，适合已经看过 ABP vNext 的文档及了解微服务架构的小伙伴们。