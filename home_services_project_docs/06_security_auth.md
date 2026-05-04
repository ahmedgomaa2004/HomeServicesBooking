# Security and Authentication Plan

## Authentication Type

سيتم استخدام Cookie Authentication مع جدول AdminUsers.

## لماذا لا نستخدم Password Plain Text؟

لأن تخزين كلمة المرور كنص عادي خطر جدًا. يجب تخزين Hash فقط.

## Password Hashing

المقترح:

- استخدام PasswordHasher من `Microsoft.AspNetCore.Identity` بدون اعتماد كامل على Identity System.
- أو استخدام Helper بسيط يعتمد على خوارزمية Hash مناسبة.

الأفضل عمليًا:

```csharp
PasswordHasher<AdminUser>
```

## Login Flow

1. استلام Email و Password.
2. التحقق من ModelState.
3. البحث عن AdminUser بالإيميل.
4. عند عدم وجود المستخدم: رسالة `بيانات غير صحيحة`.
5. عند وجود المستخدم: التحقق من PasswordHash.
6. عند النجاح: إنشاء Claims.
7. تسجيل الدخول بـ Cookie.
8. التحويل إلى Dashboard.

## Logout Flow

1. استدعاء SignOutAsync.
2. حذف Cookie.
3. التحويل إلى Login.

## Protecting Admin Area

كل Controllers داخل `Areas/Admin` يجب أن تحتوي على:

```csharp
[Area("Admin")]
[Authorize]
```

مع استثناء `AuthController.Login`.

## Anti-Forgery

كل POST Form يجب أن يحتوي على Anti-Forgery Token:

```html
@Html.AntiForgeryToken()
```

وفي Controller:

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
```

## Cookie Settings

إعدادات مقترحة:

```csharp
builder.Services.AddAuthentication("AdminCookie")
    .AddCookie("AdminCookie", options =>
    {
        options.LoginPath = "/Admin/Auth/Login";
        options.AccessDeniedPath = "/Admin/Auth/Login";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    });
```

## Seed Admin

يتم إنشاء Admin افتراضي عند بداية المشروع في التطوير:

```text
Email: admin@test.com
Password: Admin123
```

يجب تغيير هذه البيانات قبل التسليم النهائي أو توضيحها في README.

## Security Checklist

- [ ] Admin pages protected.
- [ ] Password stored as hash.
- [ ] Login has validation.
- [ ] Invalid login shows generic message.
- [ ] POST forms have Anti-Forgery Token.
- [ ] No exception details shown to user.
- [ ] Connection string not hardcoded in controllers.
