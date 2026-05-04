# Phase 10 - UI/UX and Notifications

## Goal

تحسين الواجهة العامة ولوحة التحكم وإضافة رسائل واضحة للحالات المختلفة.

## Inputs

- 07_ui_ux_guidelines.md

## Tasks

- [ ] تحسين Public Layout.
- [ ] تحسين Admin Layout.
- [ ] إضافة Navbar/Sidebar للأدمن.
- [ ] إضافة status badges.
- [ ] إضافة empty states.
- [ ] تحسين forms.
- [ ] تحسين tables.
- [ ] إضافة shared alerts أو toasts.
- [ ] توحيد النصوص العربية.

## Files/Folders Expected

- Views/Shared/_Layout.cshtml
- Areas/Admin/Views/Shared/_AdminLayout.cshtml
- Views/Shared/_Alerts.cshtml
- wwwroot/css/site.css

## Implementation Notes

- لا تغير business logic في هذه المرحلة.
- ركز على الوضوح والنظافة.
- تأكد أن الواجهة لا تكسر responsive behavior.
- استخدم Bootstrap إن كان موجودًا.

## Validation / QA

- [ ] واجهة public واضحة.
- [ ] واجهة admin واضحة.
- [ ] رسائل النجاح والخطأ تظهر جيدًا.
- [ ] Status badges تظهر.
- [ ] Build ينجح.

## Acceptance Criteria

- [ ] UI polished.
- [ ] Notifications working.
- [ ] Layouts separated.
- [ ] Build passes.

## Agent Prompt

```text
Read 07_ui_ux_guidelines.md. Improve UI and notifications only. Do not change business logic. Add shared alerts/status badges and clean admin layout. Run dotnet build.
```

## Done Checklist

- [ ] Public UI done.
- [ ] Admin UI done.
- [ ] Alerts done.
- [ ] Badges done.
- [ ] Build success.
