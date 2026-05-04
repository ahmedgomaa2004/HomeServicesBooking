# UI/UX Guidelines

## General Style

الواجهة يجب أن تكون بسيطة ونظيفة، بدون تعقيد بصري.

## Public Website

### Home Page

Recommended sections:

1. Navbar
2. Hero Section
3. Services Cards
4. How it works
5. Footer

### Services Cards

كل Card يحتوي على:

- اسم الخدمة
- وصف مختصر
- زر التفاصيل
- زر اطلب الآن

### Order Form

يجب أن يكون واضحًا وسهل الإدخال:

- Labels واضحة.
- Validation messages أسفل الحقول.
- زر إرسال واضح.
- رسالة نجاح بعد الحفظ.

## Admin Layout

يفضل فصل Layout الأدمن عن Layout الموقع العام.

Admin layout يحتوي على:

- Sidebar أو Navbar.
- Links:
  - Dashboard
  - Orders
  - Services
  - Logout

## Status Badges

الحالة تظهر كبادج:

| Status | Display |
|---|---|
| Pending | Pending |
| InProgress | In Progress |
| Done | Done |

## Notifications

النسخة الأساسية:

- Bootstrap Alerts باستخدام TempData.

Nice to have:

- Toast Notifications بدل Alerts.

## Empty States

في حالة عدم وجود بيانات:

- لا تعرض جدول فارغ فقط.
- اعرض رسالة مثل: `لا توجد طلبات حاليًا`.

## Arabic/English

بما أن العميلة كتبت بالعربي والـ statuses بالإنجليزي، المقترح:

- واجهة عربية للمستخدم.
- Admin يمكن أن يكون عربي مع Status بالإنجليزي كما طلبت.

## Accessibility Basic Rules

- استخدام labels لكل input.
- أزرار واضحة.
- Contrast جيد.
- لا تعتمد على اللون فقط لفهم الحالة.
