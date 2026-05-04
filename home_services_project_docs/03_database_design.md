# Database Design

## Database Name

الاسم المقترح:

```text
HomeServicesBookingDb
```

## Tables

## 1. Services

الغرض: تخزين الخدمات التي تظهر للمستخدم ويمكن إدارتها من لوحة التحكم.

### Columns

| Column | Type | Nullable | Notes |
|---|---|---|---|
| Id | int identity | No | Primary Key |
| Name | nvarchar(150) | No | اسم الخدمة |
| Description | nvarchar(max) | No | وصف الخدمة |
| IsActive | bit | No | لتفعيل/تعطيل الخدمة |
| CreatedAt | datetime2 | No | تاريخ الإنشاء |
| UpdatedAt | datetime2 | Yes | آخر تعديل |

### Suggested Indexes

```sql
CREATE INDEX IX_Services_IsActive ON Services(IsActive);
```

## 2. Orders

الغرض: تخزين طلبات العملاء.

### Columns

| Column | Type | Nullable | Notes |
|---|---|---|---|
| Id | int identity | No | Primary Key |
| CustomerName | nvarchar(150) | No | اسم العميل |
| Phone | nvarchar(20) | No | رقم الموبايل |
| Address | nvarchar(300) | No | العنوان |
| ServiceId | int | Yes | علاقة بالخدمة |
| ServiceName | nvarchar(150) | No | اسم الخدمة وقت الطلب |
| OrderDate | datetime2 | No | تاريخ الحجز |
| Status | nvarchar(30) | No | Pending/InProgress/Done |
| CreatedAt | datetime2 | No | تاريخ الإنشاء |
| UpdatedAt | datetime2 | Yes | آخر تعديل |

### Suggested Indexes

```sql
CREATE INDEX IX_Orders_Status ON Orders(Status);
CREATE INDEX IX_Orders_Phone ON Orders(Phone);
CREATE INDEX IX_Orders_CustomerName ON Orders(CustomerName);
CREATE INDEX IX_Orders_OrderDate ON Orders(OrderDate);
```

## 3. AdminUsers

الغرض: تخزين حسابات الأدمن.

### Columns

| Column | Type | Nullable | Notes |
|---|---|---|---|
| Id | int identity | No | Primary Key |
| Email | nvarchar(150) | No | Unique |
| PasswordHash | nvarchar(max) | No | Hash فقط |
| CreatedAt | datetime2 | No | تاريخ الإنشاء |

### Suggested Indexes

```sql
CREATE UNIQUE INDEX IX_AdminUsers_Email ON AdminUsers(Email);
```

## Relationship

```text
Service 1 ---- * Orders
```

لكن `Order.ServiceId` يمكن أن يكون nullable حتى لا تتأثر الطلبات القديمة لو تم حذف أو تعطيل الخدمة.

## Initial SQL Schema Draft

```sql
CREATE TABLE Services (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL
);

CREATE TABLE Orders (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CustomerName NVARCHAR(150) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Address NVARCHAR(300) NOT NULL,
    ServiceId INT NULL,
    ServiceName NVARCHAR(150) NOT NULL,
    OrderDate DATETIME2 NOT NULL,
    Status NVARCHAR(30) NOT NULL DEFAULT 'Pending',
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_Orders_Services_ServiceId FOREIGN KEY (ServiceId) REFERENCES Services(Id) ON DELETE SET NULL
);

CREATE TABLE AdminUsers (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Email NVARCHAR(150) NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

CREATE UNIQUE INDEX IX_AdminUsers_Email ON AdminUsers(Email);
CREATE INDEX IX_Services_IsActive ON Services(IsActive);
CREATE INDEX IX_Orders_Status ON Orders(Status);
CREATE INDEX IX_Orders_Phone ON Orders(Phone);
CREATE INDEX IX_Orders_CustomerName ON Orders(CustomerName);
CREATE INDEX IX_Orders_OrderDate ON Orders(OrderDate);
```

## EF Core Notes

يفضل أن يتم إنشاء الجداول من خلال Migrations، ثم يتم توليد SQL Script النهائي من Migration بدل كتابة قاعدة البيانات يدويًا.

أوامر مقترحة:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations script -o database.sql
```
