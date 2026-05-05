# HomeServicesBooking

نظام حجز خدمات منزلية بسيط مبني بـ ASP.NET Core MVC مع لوحة تحكم للمسؤولين.

## التقنيات المستخدمة

- **ASP.NET Core 8** MVC
- **Entity Framework Core 8** (Code First)
- **SQL Server LocalDB** (قاعدة بيانات محلية)
- **Bootstrap 5** (RTL - ملفات محلية)
- **Cookie Authentication** للمسؤولين

## المتطلبات

- .NET 8 SDK
- SQL Server Express LocalDB (يأتي مع Visual Studio)

## كيفية التشغيل

```bash
# استعادة الحزم
dotnet restore

# تطبيق migrations تلقائيًا عند التشغيل
# أو يدويًا (اختياري):
dotnet ef database update

# تشغيل المشروع
dotnet run
```

> **ملاحظة:** التطبيق يطبق migrations تلقائيًا عند التشغيل باستخدام `MigrateAsync()` في `Program.cs`. أمر `dotnet ef database update` اختياري كطريقة يدوية بديلة.

بعد التشغيل، افتح المتصفح على: `http://localhost:5038`

## قاعدة البيانات

### Connection String

```
Server=(localdb)\MSSQLLocalDB;Database=HomeServicesBookingDb;Trusted_Connection=True;MultipleActiveResultSets=true
```

### كيفية تطبيق Migrations

التطبيق يطبق migrations تلقائيًا عند كل تشغيل. لا حاجة لتشغيل أي أمر يدوي.

لو أردت التطبيق يدويًا:

```bash
dotnet ef database update
```

### SQL Script بديل

ملف `docs/database-script.sql` يحتوي على سكريبت إنشاء قاعدة البيانات كاملة مع البيانات الافتراضية.

## بيانات المسؤول

| الحقل | القيمة |
|---|---|
| البريد الإلكتروني | `admin@site.com` |
| كلمة المرور | `Admin@123` |

> يتم إنشاء هذا الحساب تلقائيًا عند أول تشغيل عبر `DbInitializer`.

## المسارات الرئيسية

### الموقع العام

| الصفحة | الرابط |
|---|---|
| الرئيسية | `/` |
| الخدمات | `/Services` |
| تفاصيل خدمة | `/Services/Details/{id}` |
| حجز خدمة | `/Orders/Create` |
| حجز خدمة محددة | `/Orders/Create?serviceId={id}` |

### لوحة التحكم (Admin)

| الصفحة | الرابط |
|---|---|
| تسجيل الدخول | `/Admin/Auth/Login` |
| لوحة التحكم | `/Admin/Dashboard` |
| إدارة الطلبات | `/Admin/Orders` |
| تفاصيل طلب | `/Admin/Orders/Details/{id}` |
| إدارة الخدمات | `/Admin/Services` |
| إضافة خدمة | `/Admin/Services/Create` |
| تعديل خدمة | `/Admin/Services/Edit/{id}` |

## الميزات

### الموقع العام
- عرض الخدمات المتاحة
- عرض تفاصيل الخدمة
- حجز خدمة مع validation كامل
- رسائل نجاح/خطأ بالعربية

### لوحة التحكم
- تسجيل دخول/خروج المسؤول
- لوحة تحكم بإحصائيات الطلبات
- إدارة الطلبات: بحث، فلترة حسب الحالة، pagination
- تفاصيل الطلب وتغيير الحالة
- إدارة الخدمات: إضافة، تعديل، تعطيل (soft delete)
- الخدمة المعطلة لا تظهر في الموقع العام
- حماية صفحات Admin بـ Cookie Authentication

### الأمان والجودة
- `[ValidateAntiForgeryToken]` على كل POST
- `[Authorize]` على كل Admin controllers
- كلمات المرور مشفرة بـ `PasswordHasher`
- `AsNoTracking()` على كل استعلامات القراءة
- Projection إلى ViewModels (لا Entity في Views)
- Logging للأخطاء المهمة
- Validation عربية على كل الحقول

## ملاحظات عن SQL Server LocalDB

- LocalDB هو نسخة خفيفة من SQL Server تأتي مع Visual Studio
- يعمل فقط على Windows
- البيانات تُحفظ في مجلد المستخدم
- لا يعمل كـ server مستقل — مناسب للتطوير فقط
- لإنتاج، استبدل Connection String بـ SQL Server حقيقي

## استكشاف الأخطاء

| المشكلة | الحل |
|---|---|
| خطأ في الاتصال بقاعدة البيانات | تأكد أن LocalDB يعمل: `sqllocaldb start mssqllocaldb` |
| صفحة Admin ترجع لـ Login | سجّل دخول أولاً من `/Admin/Auth/Login` |
| خطأ في migration | احذف قاعدة البيانات وأعد التشغيل: `sqllocaldb stop mssqllocaldb` ثم `sqllocaldb start mssqllocaldb` |
| لا تظهر خدمات | تأكد أن `DbInitializer` يعمل — الخدمات تُضاف تلقائيًا عند أول تشغيل |
