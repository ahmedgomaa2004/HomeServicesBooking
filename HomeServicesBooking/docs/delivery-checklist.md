# Delivery Checklist

## Source Code

- [x] Source code pushed to GitHub
- [x] `dotnet build` succeeds with no errors
- [x] No new migrations beyond InitialCreate
- [x] All phases (01–11) completed

## Database

- [x] EF Core migration applied successfully
- [x] `docs/database-script.sql` ready
- [x] Seed data included in script
- [x] Admin password stored as hash (not plain text)

## Documentation

- [x] `README.md` in project root
- [x] Tech stack documented
- [x] How to run documented
- [x] Admin credentials documented
- [x] Routes documented
- [x] Troubleshooting section included

## Screenshots

- [ ] Home page (`/`)
- [ ] Services list (`/Services`)
- [ ] Service details (`/Services/Details/1`)
- [ ] Order form (`/Orders/Create`)
- [ ] Admin login (`/Admin/Auth/Login`)
- [ ] Dashboard (`/Admin/Dashboard`)
- [ ] Orders list (`/Admin/Orders`)
- [ ] Order details (`/Admin/Orders/Details/1`)
- [ ] Services management (`/Admin/Services`)
- [ ] Create service (`/Admin/Services/Create`)
- [ ] Edit service (`/Admin/Services/Edit/1`)

## Demo Video

- [ ] 2–3 minute walkthrough recorded
- [ ] Covers: browsing services, submitting order, admin login, dashboard, order management, service management

## Final Testing

- [ ] Public website loads correctly
- [ ] Booking flow works end-to-end
- [ ] Admin login/logout works
- [ ] Dashboard stats display correctly
- [ ] Orders search/filter/pagination works
- [ ] Order status update works
- [ ] Services CRUD works
- [ ] Soft delete hides service from public
- [ ] No CDN references
- [ ] No runtime errors
