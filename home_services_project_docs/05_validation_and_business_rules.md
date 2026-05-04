# Validation and Business Rules

## Order Form Validation

| Field | Rule | Error Message Suggested |
|---|---|---|
| CustomerName | Required | الاسم مطلوب |
| CustomerName | Minimum 3 characters | الاسم يجب أن يكون 3 حروف على الأقل |
| Phone | Required | رقم الموبايل مطلوب |
| Phone | Digits only | رقم الموبايل يجب أن يحتوي على أرقام فقط |
| Phone | Exactly 11 digits | رقم الموبايل يجب أن يكون 11 رقم |
| Address | Required | العنوان مطلوب |
| ServiceId/ServiceName | Required | نوع الخدمة مطلوب |
| OrderDate | Required | تاريخ الحجز مطلوب |
| OrderDate | Not in the past | لا يمكن اختيار تاريخ في الماضي |

## Admin Login Validation

| Field | Rule | Error Message Suggested |
|---|---|---|
| Email | Required | البريد الإلكتروني مطلوب |
| Email | Valid format | البريد الإلكتروني غير صحيح |
| Password | Required | كلمة المرور مطلوبة |
| Password | Minimum 6 characters | كلمة المرور يجب ألا تقل عن 6 حروف |

عند فشل تسجيل الدخول بسبب بيانات غير صحيحة:

```text
بيانات غير صحيحة
```

## Service Validation

| Field | Rule | Error Message Suggested |
|---|---|---|
| Name | Required | اسم الخدمة مطلوب |
| Name | Max 150 chars | اسم الخدمة طويل جدًا |
| Description | Required | وصف الخدمة مطلوب |

## Business Rules

### BR-001 - Default Order Status

أي طلب جديد يتم إنشاؤه بحالة:

```text
Pending
```

### BR-002 - Order Date

لا يمكن اختيار تاريخ في الماضي. التاريخ الحالي أو تاريخ مستقبلي مسموح.

### BR-003 - Service Snapshot

عند إنشاء طلب، يتم حفظ `ServiceName` داخل الطلب حتى لو تم تعديل اسم الخدمة لاحقًا.

### BR-004 - Status Values

الحالات المسموحة فقط:

- Pending
- InProgress
- Done

### BR-005 - Delete Service

القرار المقترح:

- استخدام Soft Delete أو IsActive بدل حذف نهائي.
- سبب ذلك: منع كسر الطلبات القديمة.

لكن لو العميلة تريد حذف نهائي يمكن تنفيذه بشرط أن `Order.ServiceId` يكون nullable.

### BR-006 - Admin Access

أي صفحة داخل Admin Area يجب ألا تفتح إلا بعد Login.

### BR-007 - Error Messages

لا يتم عرض تفاصيل Exception للمستخدم. يتم عرض رسالة عامة واضحة.

## Data Annotations Suggested

```csharp
[Required(ErrorMessage = "الاسم مطلوب")]
[MinLength(3, ErrorMessage = "الاسم يجب أن يكون 3 حروف على الأقل")]
public string CustomerName { get; set; }

[Required(ErrorMessage = "رقم الموبايل مطلوب")]
[RegularExpression(@"^\d{11}$", ErrorMessage = "رقم الموبايل يجب أن يكون 11 رقم")]
public string Phone { get; set; }
```
