# Phase 04 - Admin Authentication

## Goal

تنفيذ تسجيل دخول وخروج الأدمن وحماية صفحات لوحة التحكم.

## Inputs

- 06_security_auth.md
- 04_routes_pages_map.md

## Tasks

- [ ] تكوين Cookie Authentication في Program.cs.
- [ ] إنشاء LoginViewModel.
- [ ] إنشاء AuthController داخل Admin Area.
- [ ] إنشاء Login GET.
- [ ] إنشاء Login POST.
- [ ] التحقق من Email و Password.
- [ ] التحقق من PasswordHash.
- [ ] إنشاء Claims وتسجيل الدخول.
- [ ] تنفيذ Logout.
- [ ] إضافة [Authorize] لباقي Admin Controllers.
- [ ] إنشاء Login View.

## Files/Folders Expected

- Areas/Admin/Controllers/AuthController.cs
- Areas/Admin/Views/Auth/Login.cshtml
- ViewModels/LoginViewModel.cs
- Program.cs

## Implementation Notes

- رسالة فشل الدخول يجب أن تكون عامة: بيانات غير صحيحة.
- لا تخبر المستخدم هل المشكلة في البريد أم كلمة المرور.
- لا تخزن Password plain text.
- تأكد أن Dashboard لا يفتح بدون Login.

## Validation / QA

- [ ] Login ببيانات صحيحة يعمل.
- [ ] Login ببيانات خطأ يعرض رسالة.
- [ ] Logout يعمل.
- [ ] Admin pages protected.
- [ ] dotnet build ينجح.

## Acceptance Criteria

- [ ] Cookie auth configured.
- [ ] Login works.
- [ ] Logout works.
- [ ] Admin protected.
- [ ] Build passes.

## Agent Prompt

```text
Read 06_security_auth.md. Implement admin login/logout using Cookie Authentication. Protect admin area. Use hashed passwords. Do not implement dashboard logic except placeholder if needed. Run dotnet build.
```

## Done Checklist

- [ ] Auth configured.
- [ ] Login view done.
- [ ] Login POST done.
- [ ] Logout done.
- [ ] Protection done.
- [ ] Build success.
