# Project Context

## خلفية المشروع

العميلة كانت تعتقد في البداية أن لديها موقعًا مبنيًا بالفعل بـ ASP.NET Core MVC ومربوطًا بـ SQL Server، وأن المطلوب هو تعديل المشروع الحالي وإصلاح مشاكل حفظ الطلبات وإضافة لوحة تحكم.

بعد ذلك أوضحت أنه لا يوجد Source Code ولا Database جاهزين، وأن المطلوب هو بناء المشروع من الصفر بنفس التفاصيل السابقة.

## النتيجة العملية

المشروع الآن عبارة عن:

- New Build Project
- Full-stack MVC Application
- Database Design from scratch
- Admin Panel from scratch
- Public Booking Flow from scratch

## أثر ذلك على السعر والمدة

بناء مشروع من الصفر يشمل وقتًا وجهدًا أكبر من تعديل مشروع موجود، لذلك يجب توثيق تغيير النطاق وإبلاغ العميلة بأن السعر والمدة سيتغيران.

## Constraints ثابتة

- لا APIs خارجية.
- لا Cloud Services.
- الاعتماد على ASP.NET Core MVC.
- الاعتماد على SQL Server.
- الكود يجب أن يكون واضحًا وسهل الفهم.
- التسليم يجب أن يحتوي على Source Code و SQL Script و README و Screenshots و Demo Video.

## أسلوب التنفيذ

يتم التنفيذ على مراحل، وكل مرحلة لها ملف مستقل داخل مجلد `phases/`.
