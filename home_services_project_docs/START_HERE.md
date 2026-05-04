# START HERE - Home Services Booking Project

هذا الملف هو نقطة البداية لأي شخص أو AI Agent سيعمل على المشروع.

## المطلوب باختصار

بناء مشروع من الصفر باستخدام:

- ASP.NET Core MVC
- SQL Server
- Entity Framework Core
- Razor Views
- Bootstrap أو تصميم بسيط مشابه

النظام عبارة عن موقع حجز خدمات منزلية مع لوحة تحكم للإدارة.

## أهم قرار في المشروع

المشروع لم يعد تعديلًا على Source Code موجود. المطلوب الآن بناء كامل من الصفر، لذلك يجب التعامل معه كـ New Build Project وليس Maintenance Project.

## اقرأ الملفات بهذا الترتيب

1. `plan.md`
2. `00_project_context.md`
3. `01_requirements.md`
4. `02_architecture.md`
5. `03_database_design.md`
6. `04_routes_pages_map.md`
7. `05_validation_and_business_rules.md`
8. `06_security_auth.md`
9. `TASK_BOARD.md`
10. ملفات المراحل داخل مجلد `phases/`
11. ملفات الـ agents داخل `agent-prompts/`

## قاعدة العمل

لا يتم تنفيذ المشروع مرة واحدة. يتم تنفيذه على مراحل صغيرة، وبعد كل مرحلة يجب عمل:

```bash
dotnet build
```

ثم اختبار يدوي سريع للجزء الذي تم تنفيذه.

## أول مرحلة تنفيذ فعلية

ابدأ من:

`phases/phase_01_project_setup.md`

ثم أكمل حسب ترتيب ملفات المراحل.
