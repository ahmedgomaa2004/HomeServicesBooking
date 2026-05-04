# Phase 00 - Scope and Kickoff

## Goal

تثبيت أن المشروع بناء من الصفر، وتوثيق تغيير السعر والمدة قبل الدخول في تنفيذ كبير.

## Inputs

- رسالة العميلة التي تؤكد عدم وجود Source Code أو Database.
- ملف 10_client_message_price_change.md.
- المنصة التي سيتم الاتفاق عليها داخلها.

## Tasks

- [ ] إرسال رسالة تغيير السعر للعميلة.
- [ ] توضيح أن المشروع New Build وليس تعديل.
- [ ] طلب اعتماد Extra Service أو Milestone إضافي.
- [ ] توثيق أي رد من العميلة.
- [ ] تسجيل الافتراضات في risks_and_assumptions.md.

## Files/Folders Expected

- 10_client_message_price_change.md
- risks_and_assumptions.md
- decisions_log.md

## Implementation Notes

- لا تبدأ تنفيذ كامل قبل توضيح فرق السعر.
- يمكن البدء في التخطيط وتجهيز structure فقط.
- لا تدخل في نقاش طويل؛ الرسالة تكون واضحة ومهنية.

## Validation / QA

- [ ] تم إرسال الرسالة.
- [ ] تم حفظ رد العميلة.
- [ ] تم تحديث Decisions Log عند الموافقة.

## Acceptance Criteria

- [ ] العميلة فهمت أن النطاق تغير.
- [ ] يوجد اتفاق واضح بخصوص السعر/المدة.
- [ ] الفريق يستطيع بدء التنفيذ بدون لبس.

## Agent Prompt

```text
Read 10_client_message_price_change.md and prepare a concise message to confirm scope and price change. Do not write code in this phase.
```

## Done Checklist

- [ ] Scope documented.
- [ ] Price change message ready.
- [ ] No code implementation started before approval.
