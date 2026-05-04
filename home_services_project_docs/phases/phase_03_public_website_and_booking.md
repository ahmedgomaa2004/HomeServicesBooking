# Phase 03 - Public Website and Booking Flow

## Goal

بناء صفحات المستخدم العادي: الصفحة الرئيسية، الخدمات، تفاصيل الخدمة، ونموذج الحجز مع حفظ الطلب.

## Inputs

- 01_requirements.md
- 04_routes_pages_map.md
- 05_validation_and_business_rules.md

## Tasks

- [ ] بناء Home Page.
- [ ] عرض الخدمات النشطة في Home أو Services Page.
- [ ] بناء ServicesController Index.
- [ ] بناء Service Details Page.
- [ ] إضافة زر احجز الخدمة.
- [ ] بناء OrdersController Create GET.
- [ ] بناء OrdersController Create POST.
- [ ] إنشاء OrderFormViewModel.
- [ ] تطبيق validation.
- [ ] حفظ الطلب في قاعدة البيانات.
- [ ] إظهار رسالة نجاح أو خطأ.

## Files/Folders Expected

- Controllers/HomeController.cs
- Controllers/ServicesController.cs
- Controllers/OrdersController.cs
- ViewModels/OrderFormViewModel.cs
- Views/Home/Index.cshtml
- Views/Services/Index.cshtml
- Views/Services/Details.cshtml
- Views/Orders/Create.cshtml
- Views/Shared/_Alerts.cshtml

## Implementation Notes

- استخدم services من قاعدة البيانات بدل static data قدر الإمكان.
- عند فتح الفورم من خدمة محددة مرر serviceId.
- تأكد من اختيار الخدمة تلقائيًا.
- لا تحفظ الطلب لو ModelState غير صالح.
- Default status = Pending.
- استخدم TempData لرسائل النجاح والخطأ.

## Validation / QA

- [ ] إرسال طلب صحيح يحفظ في Orders.
- [ ] رقم غير صحيح يمنع الحفظ.
- [ ] تاريخ قديم يمنع الحفظ.
- [ ] رسالة النجاح تظهر.
- [ ] dotnet build ينجح.

## Acceptance Criteria

- [ ] Public pages implemented.
- [ ] Booking form works.
- [ ] Validation works.
- [ ] Order saved.
- [ ] Build passes.

## Agent Prompt

```text
Read phase_03_public_website_and_booking.md and validation rules. Implement only public website and booking flow. Use OrderFormViewModel. Save valid orders with Pending status. Show TempData messages. Run dotnet build.
```

## Done Checklist

- [ ] Home done.
- [ ] Services list done.
- [ ] Details done.
- [ ] Order form done.
- [ ] Save order done.
- [ ] Validation done.
- [ ] Build success.
