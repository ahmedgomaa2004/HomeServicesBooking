# Routes and Pages Map

## Public Routes

| Route | Controller | Action | Purpose |
|---|---|---|---|
| `/` | HomeController | Index | الصفحة الرئيسية |
| `/Services` | ServicesController | Index | عرض الخدمات |
| `/Services/Details/{id}` | ServicesController | Details | تفاصيل الخدمة |
| `/Orders/Create` | OrdersController | Create GET | فتح نموذج الحجز |
| `/Orders/Create` | OrdersController | Create POST | إرسال نموذج الحجز |

## Admin Routes

| Route | Area | Controller | Action | Protected |
|---|---|---|---|---|
| `/Admin/Auth/Login` | Admin | AuthController | Login GET | No |
| `/Admin/Auth/Login` | Admin | AuthController | Login POST | No |
| `/Admin/Auth/Logout` | Admin | AuthController | Logout POST/GET | Yes |
| `/Admin/Dashboard` | Admin | DashboardController | Index | Yes |
| `/Admin/Orders` | Admin | OrdersController | Index | Yes |
| `/Admin/Orders/Details/{id}` | Admin | OrdersController | Details | Yes |
| `/Admin/Orders/UpdateStatus/{id}` | Admin | OrdersController | UpdateStatus | Yes |
| `/Admin/Services` | Admin | ServicesController | Index | Yes |
| `/Admin/Services/Create` | Admin | ServicesController | Create | Yes |
| `/Admin/Services/Edit/{id}` | Admin | ServicesController | Edit | Yes |
| `/Admin/Services/Delete/{id}` | Admin | ServicesController | Delete | Yes |

## Views Map

```text
Views/
├── Home/
│   └── Index.cshtml
├── Services/
│   ├── Index.cshtml
│   └── Details.cshtml
├── Orders/
│   └── Create.cshtml
└── Shared/
    ├── _Layout.cshtml
    ├── _ValidationScriptsPartial.cshtml
    └── _Alerts.cshtml

Areas/Admin/Views/
├── Auth/
│   └── Login.cshtml
├── Dashboard/
│   └── Index.cshtml
├── Orders/
│   ├── Index.cshtml
│   └── Details.cshtml
├── Services/
│   ├── Index.cshtml
│   ├── Create.cshtml
│   ├── Edit.cshtml
│   └── Delete.cshtml
└── Shared/
    └── _AdminLayout.cshtml
```

## Query Parameters

### Orders Management

```text
/Admin/Orders?search=ahmed&status=Pending&page=1
```

Parameters:

| Name | Type | Purpose |
|---|---|---|
| search | string | البحث بالاسم أو الموبايل |
| status | string | فلترة حسب الحالة |
| page | int | رقم الصفحة |

## Redirect Rules

- بعد Login ناجح: `/Admin/Dashboard`
- بعد Logout: `/Admin/Auth/Login`
- بعد إرسال طلب ناجح: البقاء في صفحة الحجز مع رسالة نجاح أو التحويل لصفحة نجاح حسب التنفيذ.
- بعد تحديث حالة طلب: العودة لتفاصيل الطلب أو صفحة الطلبات مع رسالة نجاح.
- بعد CRUD للخدمات: العودة لقائمة الخدمات.
