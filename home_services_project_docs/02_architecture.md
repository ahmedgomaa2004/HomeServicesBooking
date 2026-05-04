# Architecture Document

## Architecture Style

سيتم استخدام ASP.NET Core MVC بنمط Layered MVC بسيط:

- Models: تمثل Entities الخاصة بقاعدة البيانات.
- ViewModels: تمثل البيانات التي تحتاجها الواجهات فقط.
- Controllers: تستقبل الطلبات وتنفذ المنطق البسيط وتتعامل مع DbContext.
- Views: Razor Views لعرض HTML.
- Data Layer: ApplicationDbContext و Seed Data.
- Helpers: أدوات مساعدة مثل Date Validation و Password Hashing.

## Main Areas

### Public Area

المسارات العامة لا تحتاج Login:

- `/`
- `/Services`
- `/Services/Details/{id}`
- `/Orders/Create`

### Admin Area

المسارات الإدارية تحتاج Login:

- `/Admin/Auth/Login`
- `/Admin/Auth/Logout`
- `/Admin/Dashboard`
- `/Admin/Orders`
- `/Admin/Orders/Details/{id}`
- `/Admin/Services`

## Folder Structure

```text
HomeServicesBooking/
├── Areas/Admin
├── Controllers
├── Data
├── Models
├── ViewModels
├── Helpers
├── Views
└── wwwroot
```

## Data Access

يتم استخدام Entity Framework Core مع SQL Server.

قواعد مهمة:

- استخدم `AsNoTracking()` في القوائم.
- استخدم ViewModels في صفحات العرض.
- لا تمرر Entity للـ View إلا عند الحاجة وبحذر.
- استخدم async methods قدر الإمكان.

## Authentication

يتم استخدام Cookie Authentication.

تدفق المصادقة:

1. الأدمن يدخل Email و Password.
2. النظام يبحث عن Email.
3. يتحقق من Password Hash.
4. عند النجاح يتم إنشاء ClaimsPrincipal.
5. يتم تسجيل الدخول باستخدام Cookie.
6. صفحات Admin محمية بـ `[Authorize]`.

## Routing

يجب تفعيل Area Routing في `Program.cs`:

```csharp
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

## Error Handling

- استخدم Developer Exception Page في بيئة التطوير.
- استخدم Error Page في بيئة الإنتاج.
- استخدم Logging لكل Exception مهم.
- استخدم TempData لرسائل النجاح والخطأ.

## Security Considerations

- عدم تخزين Password عادي.
- حماية Admin Area.
- استخدام Anti-Forgery Token في POST forms.
- عدم الثقة في input من المستخدم.
- Validation في ViewModel و Controller.

## Performance Considerations

- Pagination للطلبات.
- Projection للـ ViewModels.
- Indexes في قاعدة البيانات.
- تجنب تحميل العلاقات غير المطلوبة.

## Future Scalability

يمكن لاحقًا إضافة:

- ASP.NET Core Identity بدل نظام الأدمن البسيط.
- Roles and Permissions.
- AJAX status update.
- Toast notifications.
- Export orders to Excel.
- Customer tracking page.
