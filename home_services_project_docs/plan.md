# Project Plan - Home Services Booking System

## 1. Project Overview

المشروع عبارة عن نظام حجز خدمات أونلاين شبيه بخدمات الصيانة المنزلية. المستخدم العادي يستطيع تصفح الخدمات، فتح تفاصيل الخدمة، ثم إرسال طلب حجز. الأدمن يستطيع تسجيل الدخول إلى لوحة تحكم لإدارة الطلبات والخدمات ومتابعة الإحصائيات.

المشروع سيتم بناؤه من الصفر باستخدام ASP.NET Core MVC و SQL Server، بدون استخدام APIs خارجية أو خدمات Cloud.

## 2. Scope Change

في بداية التواصل كان المطلوب تعديل مشروع موجود وإصلاح مشاكل في حفظ الطلبات وتحديث الحالة. بعد توضيح العميلة، لا يوجد Source Code ولا Database جاهزين، وبالتالي أصبح المطلوب:

- إنشاء مشروع جديد كامل.
- تصميم قاعدة بيانات جديدة.
- بناء كل الصفحات العامة وصفحات الإدارة.
- تنفيذ Authentication للأدمن.
- تنفيذ Dashboard وإدارة طلبات وخدمات.
- تجهيز التسليمات النهائية.

هذا التغيير يعني أن السعر والمدة يجب أن يتغيرا لأن نطاق العمل أصبح أكبر من مجرد تعديل.

## 3. Business Goals

هدف المشروع هو توفير نظام بسيط وعملي يسمح بـ:

- عرض الخدمات المتاحة للعملاء.
- استقبال طلبات الحجز بطريقة منظمة.
- حفظ الطلبات في SQL Server بدون فقدان بيانات.
- تمكين الأدمن من متابعة وإدارة الطلبات.
- تحديث حالة الطلب من Pending إلى In Progress ثم Done.
- إدارة الخدمات بدون تعديل الكود.
- تسليم مشروع قابل للتشغيل والفهم والتطوير.

## 4. User Roles

### 4.1 Public User / Customer

صلاحيات المستخدم العادي:

- عرض الصفحة الرئيسية.
- عرض قائمة الخدمات.
- عرض تفاصيل خدمة معينة.
- فتح نموذج الحجز.
- إرسال طلب حجز.
- رؤية رسالة نجاح أو خطأ بعد الإرسال.

### 4.2 Admin

صلاحيات الأدمن:

- تسجيل الدخول.
- تسجيل الخروج.
- رؤية Dashboard.
- رؤية إحصائيات الطلبات.
- البحث والفلترة داخل الطلبات.
- عرض تفاصيل أي طلب.
- تحديث حالة الطلب.
- إدارة الخدمات: إضافة، تعديل، حذف، عرض.

## 5. Main Modules

### 5.1 Public Website Module

يشمل:

- Home Page
- Services List
- Service Details
- Order Form
- Submit Order
- Success/Error messages

### 5.2 Admin Authentication Module

يشمل:

- Admin Login Page
- Validate Email and Password
- Cookie Authentication
- Logout
- Protect Admin Area

### 5.3 Dashboard Module

يشمل:

- Total Orders Count
- Pending Orders Count
- Done Orders Count
- Last 10 Orders Table

### 5.4 Orders Management Module

يشمل:

- Orders Table
- Search by CustomerName or Phone
- Filter by Status
- Pagination: 10 rows per page
- Details Page
- Change Status

### 5.5 Services Management Module

يشمل:

- List Services
- Create Service
- Edit Service
- Delete Service
- Validation

## 6. Required Screens

## 6.1 Public Screens

### Home Page

الغرض:

- تعريف المستخدم بالخدمات.
- عرض الخدمات الأساسية.
- زر طلب الخدمة.

المحتوى:

- Hero section بسيط.
- Cards للخدمات.
- زر `اطلب الآن` لكل خدمة.

### Service Details Page

الغرض:

- عرض اسم ووصف الخدمة.
- توفير زر `احجز الخدمة`.

Behavior:

- عند الضغط على `احجز الخدمة` يتم فتح Order Form مع تحديد الخدمة تلقائيًا.

### Order Form Page

الحقول:

- الاسم
- رقم الموبايل
- العنوان
- نوع الخدمة
- تاريخ الحجز

Behavior:

- عند نجاح الحفظ تظهر رسالة: `تم إرسال طلبك بنجاح`.
- عند فشل الحفظ تظهر رسالة خطأ واضحة.
- لا يتم حفظ طلب غير صالح.

## 6.2 Admin Screens

### Admin Login

الحقول:

- Email
- Password

Validation:

- Email بصيغة صحيحة.
- Password لا يقل عن 6 حروف.
- في حالة بيانات خطأ تظهر رسالة: `بيانات غير صحيحة`.

### Dashboard

المحتوى:

- عدد الطلبات الكلي.
- عدد الطلبات الجديدة Pending.
- عدد الطلبات المكتملة Done.
- جدول آخر 10 طلبات.

### Orders Management

المحتوى:

- جدول بكل الطلبات.
- Search box.
- Status filter.
- Pagination.
- زر Details.
- زر أو dropdown لتغيير الحالة.

### Order Details

المحتوى:

- كل بيانات الطلب.
- Dropdown لتغيير الحالة.
- زر حفظ التغيير.

### Services Management

المحتوى:

- عرض الخدمات.
- إضافة خدمة.
- تعديل خدمة.
- حذف خدمة.

## 7. Data Model

### 7.1 Order

الحقول المقترحة:

| Field | Type | Notes |
|---|---|---|
| Id | int | Primary Key |
| CustomerName | string | Required, min 3 chars |
| Phone | string | Required, digits only, 11 digits |
| Address | string | Required |
| ServiceId | int? | Optional relationship to Service |
| ServiceName | string | Snapshot of service name at order time |
| OrderDate | DateTime | Cannot be in the past |
| Status | enum/string | Pending, In Progress, Done |
| CreatedAt | DateTime | Auto set |
| UpdatedAt | DateTime? | Set on update |

### 7.2 Service

| Field | Type | Notes |
|---|---|---|
| Id | int | Primary Key |
| Name | string | Required |
| Description | string | Required/optional حسب التصميم |
| IsActive | bool | لعدم حذف الخدمات نهائيًا عند الحاجة |
| CreatedAt | DateTime | Auto set |
| UpdatedAt | DateTime? | Set on update |

### 7.3 AdminUser

| Field | Type | Notes |
|---|---|---|
| Id | int | Primary Key |
| Email | string | Unique |
| PasswordHash | string | Hashed password |
| CreatedAt | DateTime | Auto set |

## 8. Status Values

القيم المستخدمة للطلب:

- Pending
- InProgress
- Done

داخل الواجهة يمكن عرض `InProgress` باسم `In Progress`.

يفضل استخدام Enum في الكود لتقليل أخطاء الكتابة.

## 9. Technical Stack

- ASP.NET Core MVC
- SQL Server
- Entity Framework Core
- Razor Views
- Cookie Authentication
- Bootstrap أو CSS بسيط
- TempData Alerts أو Toast Notifications
- No External APIs
- No Cloud Services

## 10. Recommended Project Structure

```text
HomeServicesBooking/
├── Areas/
│   └── Admin/
│       ├── Controllers/
│       │   ├── AuthController.cs
│       │   ├── DashboardController.cs
│       │   ├── OrdersController.cs
│       │   └── ServicesController.cs
│       └── Views/
│           ├── Auth/
│           ├── Dashboard/
│           ├── Orders/
│           └── Services/
├── Controllers/
│   ├── HomeController.cs
│   ├── ServicesController.cs
│   └── OrdersController.cs
├── Data/
│   ├── ApplicationDbContext.cs
│   └── DbInitializer.cs
├── Models/
│   ├── AdminUser.cs
│   ├── Order.cs
│   ├── OrderStatus.cs
│   └── Service.cs
├── ViewModels/
│   ├── LoginViewModel.cs
│   ├── DashboardViewModel.cs
│   ├── OrderFormViewModel.cs
│   ├── OrderDetailsViewModel.cs
│   ├── OrdersListViewModel.cs
│   └── ServiceFormViewModel.cs
├── Helpers/
│   ├── DateNotInPastAttribute.cs
│   └── PasswordHasher.cs
├── Views/
│   ├── Home/
│   ├── Services/
│   ├── Orders/
│   └── Shared/
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── images/
├── appsettings.json
├── Program.cs
└── README.md
```

## 11. Authentication Approach

المقترح:

- جدول `AdminUsers`.
- تخزين PasswordHash فقط وليس Password عادي.
- استخدام Cookie Authentication.
- حماية كل Controllers داخل `Areas/Admin` باستخدام `[Authorize]`.
- Login و Logout داخل `Admin/AuthController`.

سبب الاختيار:

- مناسب جدًا لنظام Admin بسيط.
- أخف من ASP.NET Core Identity.
- قابل للتطوير لاحقًا.

## 12. Validation Rules

### Order Form

| Field | Rule |
|---|---|
| CustomerName | Required, minimum 3 characters |
| Phone | Required, digits only, exactly 11 digits |
| Address | Required |
| Service | Required |
| OrderDate | Required, cannot be in the past |

### Admin Login

| Field | Rule |
|---|---|
| Email | Required, valid email format |
| Password | Required, minimum 6 characters |

### Service Form

| Field | Rule |
|---|---|
| Name | Required, max reasonable length |
| Description | Required or optional حسب الاتفاق، يفضل Required |

## 13. Business Flows

### 13.1 Booking Flow

1. المستخدم يفتح Home Page.
2. يختار خدمة.
3. يفتح Service Details.
4. يضغط `احجز الخدمة`.
5. يفتح Order Form والخدمة محددة تلقائيًا.
6. المستخدم يدخل البيانات.
7. النظام يتحقق من البيانات.
8. النظام يحفظ الطلب في SQL Server.
9. تظهر رسالة نجاح.

### 13.2 Admin Login Flow

1. الأدمن يفتح `/Admin/Auth/Login`.
2. يدخل Email و Password.
3. النظام يتحقق من Validation.
4. النظام يبحث عن المستخدم.
5. النظام يتحقق من Password Hash.
6. عند النجاح يتم إنشاء Cookie.
7. يتم تحويل الأدمن إلى Dashboard.
8. عند الفشل تظهر رسالة `بيانات غير صحيحة`.

### 13.3 Order Status Update Flow

1. الأدمن يفتح تفاصيل الطلب.
2. يختار حالة جديدة.
3. يضغط حفظ.
4. النظام يحدث الطلب في قاعدة البيانات.
5. يتم تحديث `UpdatedAt`.
6. تظهر رسالة `تم تحديث الحالة`.

## 14. Performance Guidelines

- استخدم `AsNoTracking()` في صفحات العرض التي لا تحتاج تعديل مباشر.
- استخدم Pagination في Orders Management.
- لا تحمل كل الطلبات مرة واحدة.
- استخدم Projection إلى ViewModel بدل تمرير Entity مباشرة للـ View في القوائم.
- أضف Indexes على الحقول المستخدمة في البحث والفلترة:
  - Status
  - Phone
  - CustomerName
  - OrderDate
- تجنب Include غير الضروري.

## 15. Error Handling and Logging

- استخدم `try/catch` في عمليات الحفظ المهمة.
- لا تعرض تفاصيل الاستثناء للمستخدم النهائي.
- اعرض رسالة واضحة مثل: `حدث خطأ أثناء حفظ الطلب، حاول مرة أخرى`.
- استخدم Logging الداخلي المتاح في ASP.NET Core.
- سجل الأخطاء في Console/Debug أو ملف حسب الإعدادات النهائية.

## 16. UI Guidelines

- تصميم بسيط ونظيف.
- استخدام Navbar واضح.
- فصل Admin Layout عن Public Layout.
- استخدام Cards للخدمات.
- استخدام Tables منظمة للطلبات.
- استخدام Badge للحالة:
  - Pending
  - In Progress
  - Done
- استخدام Alerts أو Toasts لرسائل النجاح والخطأ.

## 17. Delivery Requirements

التسليم النهائي يجب أن يحتوي على:

- Source Code كامل.
- SQL Server Database Script.
- README يشرح التشغيل.
- Screenshots لكل الصفحات.
- فيديو قصير 2-3 دقائق يوضح النظام.

## 18. Phase Summary

| Phase | Name | Main Output |
|---|---|---|
| 00 | Scope and Kickoff | تثبيت النطاق والتسعير |
| 01 | Project Setup | مشروع MVC قابل للتشغيل |
| 02 | Database and Models | EF Models + DbContext + Migration |
| 03 | Public Website | Home + Services + Booking Form |
| 04 | Admin Authentication | Login/Logout + Protected Admin |
| 05 | Dashboard | إحصائيات وآخر 10 طلبات |
| 06 | Orders Management | جدول + بحث + فلترة + Pagination |
| 07 | Order Details | تفاصيل وتحديث حالة |
| 08 | Services CRUD | إدارة الخدمات كاملة |
| 09 | Validation/Error Handling | قواعد تحقق ورسائل أخطاء |
| 10 | UI/UX | تحسين واجهة وتنبيهات |
| 11 | Testing/QA | اختبار شامل |
| 12 | Delivery | README + SQL Script + Screenshots + Video |

## 19. Definition of Done

المشروع يعتبر مكتمل عندما:

- يستطيع المستخدم إرسال طلب صحيح ويتم حفظه في قاعدة البيانات.
- لا يتم حفظ الطلبات غير الصالحة.
- يستطيع الأدمن تسجيل الدخول والخروج.
- كل صفحات Admin محمية.
- Dashboard يعرض أرقام صحيحة.
- صفحة الطلبات تدعم البحث والفلترة والتقسيم لصفحات.
- يمكن تغيير حالة الطلب ويتم حفظها.
- يمكن إضافة وتعديل وحذف الخدمات.
- توجد رسائل نجاح وخطأ واضحة.
- يوجد README واضح.
- يوجد SQL Script.
- يوجد Screenshots وفيديو تسليم.

## 20. Open Questions for Client

هذه الأسئلة يمكن إرسالها مرة واحدة فقط لو احتجنا توضيح:

1. ما بيانات الأدمن الافتراضية المطلوبة؟
2. ما أسماء الخدمات الأولى التي تريدين ظهورها؟
3. هل تفضلي واجهة عربية بالكامل أم إنجليزية؟
4. هل حذف الخدمة يكون حذف نهائي أم إخفاء/تعطيل فقط؟
5. هل مطلوب صفحة تأكيد بعد إرسال الطلب أم رسالة نجاح تكفي؟

في حالة عدم الرد، نستخدم بيانات تجريبية قابلة للتعديل.

## 21. Default Seed Data

### Admin

```text
Email: admin@test.com
Password: Admin123
```

### Services

```text
صيانة كهرباء
صيانة سباكة
صيانة تكييف
تنظيف منازل
نجارة
دهانات
```

## 22. Execution Rule for AI Agents

أي Agent يعمل على المشروع يجب أن:

- يقرأ هذا الملف أولًا.
- لا يضيف Features خارج النطاق بدون توثيقها.
- يعمل Phase واحدة في كل مرة.
- يكتب كود واضح ومنظم.
- يتأكد من نجاح `dotnet build` بعد كل Phase.
- لا يستخدم APIs خارجية أو Cloud.
- لا يخزن Password عادي في قاعدة البيانات.
