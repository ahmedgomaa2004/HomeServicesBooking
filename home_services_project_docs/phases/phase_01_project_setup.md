# Phase 01 - Project Setup

## Goal

إنشاء مشروع ASP.NET Core MVC قابل للتشغيل وتجهيز الهيكل الأساسي للمجلدات والإعدادات.

## Inputs

- plan.md
- 02_architecture.md
- AGENTS.md

## Tasks

- [ ] إنشاء solution أو project باسم HomeServicesBooking.
- [ ] تشغيل المشروع والتأكد من فتح Home الافتراضية.
- [ ] إضافة folders: Models, ViewModels, Data, Helpers.
- [ ] إضافة Area باسم Admin.
- [ ] تجهيز Admin folders للـ Controllers والـ Views.
- [ ] تجهيز routing الخاص بالـ Areas في Program.cs.
- [ ] إضافة ملف appsettings.json بإعداد ConnectionStrings placeholder.
- [ ] تشغيل dotnet build.

## Files/Folders Expected

- HomeServicesBooking.csproj
- Program.cs
- appsettings.json
- Models/
- ViewModels/
- Data/
- Helpers/
- Areas/Admin/Controllers/
- Areas/Admin/Views/

## Implementation Notes

- لا تضف Models كاملة في هذه المرحلة إلا لو كان ضروريًا لبناء المشروع.
- ركز على أن المشروع يعمل وأن الـ routing قابل للتوسع.
- لا تستخدم أي API خارجي.
- اجعل أسماء الملفات واضحة.

## Validation / QA

- [ ] dotnet build ينجح.
- [ ] الموقع يفتح محليًا.
- [ ] Area routing لا يكسر default routing.

## Acceptance Criteria

- [ ] Project created.
- [ ] Folder structure ready.
- [ ] Admin Area routing configured.
- [ ] Build passes.

## Agent Prompt

```text
Read plan.md, 02_architecture.md, and AGENTS.md. Set up the ASP.NET Core MVC project structure only. Configure area routing. Do not implement database or UI features yet. Run dotnet build and fix errors.
```

## Done Checklist

- [ ] Project runs.
- [ ] Folders created.
- [ ] Area route configured.
- [ ] Build success.
