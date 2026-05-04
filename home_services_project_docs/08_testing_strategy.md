# Testing Strategy

## Testing Goal

الهدف هو التأكد أن المشروع يعمل بدون مشاكل في المسارات الأساسية قبل التسليم.

## Manual Testing Scenarios

### Public Website

#### TC-001 - Open Home Page

Steps:

1. افتح `/`.
2. تأكد أن الخدمات تظهر.
3. تأكد أن أزرار الطلب تعمل.

Expected:

- الصفحة تعمل بدون أخطاء.
- الخدمات تظهر بشكل واضح.

#### TC-002 - Open Service Details

Steps:

1. افتح خدمة من الصفحة الرئيسية.
2. اضغط تفاصيل.

Expected:

- تظهر اسم الخدمة ووصفها.
- يظهر زر الحجز.

#### TC-003 - Create Valid Order

Steps:

1. افتح Order Form.
2. أدخل بيانات صحيحة.
3. اضغط إرسال.

Expected:

- يتم حفظ الطلب في قاعدة البيانات.
- تظهر رسالة `تم إرسال طلبك بنجاح`.

#### TC-004 - Invalid Phone

Steps:

1. أدخل رقم موبايل أقل من 11 رقم أو يحتوي على حروف.
2. اضغط إرسال.

Expected:

- لا يتم الحفظ.
- تظهر رسالة Validation.

#### TC-005 - Past Date

Steps:

1. اختر تاريخ في الماضي.
2. اضغط إرسال.

Expected:

- لا يتم الحفظ.
- تظهر رسالة أن التاريخ لا يمكن أن يكون في الماضي.

### Admin

#### TC-006 - Invalid Login

Steps:

1. افتح `/Admin/Auth/Login`.
2. أدخل بيانات خطأ.

Expected:

- تظهر رسالة `بيانات غير صحيحة`.

#### TC-007 - Valid Login

Steps:

1. أدخل بيانات Admin صحيحة.
2. اضغط Login.

Expected:

- يتم التحويل إلى Dashboard.

#### TC-008 - Dashboard Counts

Steps:

1. افتح Dashboard.
2. قارن الأرقام بعدد الطلبات في قاعدة البيانات.

Expected:

- الأرقام صحيحة.

#### TC-009 - Orders Search

Steps:

1. افتح `/Admin/Orders`.
2. ابحث باسم عميل موجود.

Expected:

- تظهر الطلبات المطابقة فقط.

#### TC-010 - Orders Filter

Steps:

1. اختر Status = Pending.

Expected:

- تظهر طلبات Pending فقط.

#### TC-011 - Pagination

Steps:

1. أنشئ أكثر من 10 طلبات.
2. افتح صفحة الطلبات.

Expected:

- تظهر 10 طلبات فقط في الصفحة.
- تظهر أزرار التنقل بين الصفحات.

#### TC-012 - Update Order Status

Steps:

1. افتح تفاصيل طلب.
2. غير الحالة.
3. اضغط حفظ.

Expected:

- يتم تحديث الحالة في قاعدة البيانات.
- تظهر رسالة `تم تحديث الحالة`.

#### TC-013 - Services CRUD

Steps:

1. أضف خدمة.
2. عدل الخدمة.
3. احذف أو عطّل الخدمة.

Expected:

- العمليات تتم بنجاح.
- التغييرات تظهر في قائمة الخدمات.

## Build Check

بعد كل مرحلة:

```bash
dotnet build
```

## Database Check

استخدم SQL Server للتحقق من:

```sql
SELECT * FROM Orders ORDER BY CreatedAt DESC;
SELECT * FROM Services;
SELECT * FROM AdminUsers;
```

## Final QA Checklist

- [ ] كل الصفحات تفتح بدون exceptions.
- [ ] كل Forms تعمل Validation.
- [ ] لا توجد كلمات مرور plain text.
- [ ] الطلبات تحفظ.
- [ ] الحالات تتحدث.
- [ ] الخدمات تضاف وتتعدل وتحذف.
- [ ] README واضح.
- [ ] SQL Script موجود.
- [ ] Screenshots جاهزة.
- [ ] Demo Video جاهز.
