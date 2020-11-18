# Yrihr-Microservice  

## 微服务解决方案

* Ocelot网关，多个Web应用程序, 每个应用都使用不同的API网关.
* 包含使用IdentityServer4身份认证服务，SSO(单点登陆)应用程序.
* 采用不同类型的数据库: SQL Server、MySql、MongoDB.
* 使用 Redis 做分布式缓存.
* 使用 RabbitMQ 做服务间的消息传递.
* 使用 Docker 来部署&运行所有的服务和应用程序.
* 使用 Elasticsearch & Logstash & Kibana 来存储和可视化日志

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

