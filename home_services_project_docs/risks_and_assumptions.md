# Risks and Assumptions

## Assumptions

- المشروع سيتم بناؤه من الصفر.
- لا توجد قاعدة بيانات موجودة.
- لا توجد متطلبات UI Design محددة من العميلة.
- لا توجد APIs خارجية.
- لا توجد حاجة لتسجيل دخول المستخدمين العاديين.
- Admin واحد يكفي كبداية.
- الخدمات يمكن إدارتها من لوحة التحكم.
- اللغة الأساسية للواجهة ستكون عربية مع إبقاء Status values بالإنجليزية.

## Risks

### Risk 001 - Scope Expansion

قد تطلب العميلة ميزات إضافية مثل إرسال SMS أو Email أو Payment.

Mitigation:

- توثيق Out of Scope بوضوح.
- أي إضافة يتم احتسابها كـ Milestone إضافي.

### Risk 002 - Price Disagreement

قد لا توافق العميلة على تعديل السعر.

Mitigation:

- إرسال رسالة واضحة ومحترمة تشرح أن النطاق تغير من تعديل إلى بناء كامل.

### Risk 003 - Environment Issues

قد تظهر مشاكل في SQL Server أو dotnet environment.

Mitigation:

- كتابة README واضح.
- استخدام connection string قابل للتعديل.

### Risk 004 - Password Handling

تخزين كلمة مرور بطريقة غير آمنة.

Mitigation:

- استخدام PasswordHash وعدم تخزين Password كنص عادي.

### Risk 005 - Deleting Services Used in Orders

حذف خدمة مرتبطة بطلبات قد يسبب مشاكل.

Mitigation:

- استخدام IsActive أو جعل ServiceId nullable.

## Client Clarifications

الأسئلة التي يمكن إرسالها مرة واحدة:

1. بيانات الأدمن الافتراضية.
2. أسماء الخدمات الأولية.
3. لغة الواجهة النهائية.
4. حذف الخدمة نهائي أم تعطيل؟
5. هل المطلوب Toasts أم Alerts تكفي؟
