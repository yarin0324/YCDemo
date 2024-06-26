# YCDemo

**以3-layer architecture規劃半前後端分離專案，並以IoC/DI方式斷開各層間之耦合。**

**整體拆分為Web、API、Service、Dao、Entity、Infrastructure等六部分，分別說明如下:**

![image](https://github.com/yarin0324/YCDemo/blob/main/%E6%9E%B6%E6%A7%8B%E8%AA%AA%E6%98%8E.jpg)

***

**展示層**

Web: 以.Net Core MVC實作，提供頁面給使用者操作互動使用。

API: 以.Net Core 實作RESTful Web API，供Web端調用服務，並以AOP方式於Interface端實作錯誤攔截。

***

**業務邏輯層**

Service: 放置業務邏輯。

***

**資料存取層**

Dao: 以Unit of Work Pattern實作資料操作相關功能。

***

**共用專案:**

Entity: 資料表映射模型與數據傳輸容器，因專案規模不另設計拆分DTO。

Infrastructure: 基礎設施，提供專案基礎功能。
