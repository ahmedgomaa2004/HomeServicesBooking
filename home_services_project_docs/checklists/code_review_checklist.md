# Code Review Checklist

## Controllers

- [ ] Controller actions are small and readable.
- [ ] POST actions use `[ValidateAntiForgeryToken]`.
- [ ] Admin controllers use `[Authorize]`.
- [ ] Admin controllers use `[Area("Admin")]`.
- [ ] No business-critical validation is missing.
- [ ] Errors are logged where needed.

## Models and ViewModels

- [ ] Entities represent database tables only.
- [ ] ViewModels are used for forms and list pages.
- [ ] Data annotations are applied.
- [ ] No plain text password field is stored in AdminUser.

## Database

- [ ] DbContext is registered.
- [ ] Relationships are configured.
- [ ] Indexes are configured for common queries.
- [ ] Migrations are valid.

## Views

- [ ] Forms display validation messages.
- [ ] Forms contain anti-forgery tokens.
- [ ] Layouts are separated for Public/Admin.
- [ ] Empty states exist for empty tables.
- [ ] Status badges are clear.

## Security

- [ ] Passwords are hashed.
- [ ] Admin area is protected.
- [ ] Login failure does not reveal whether email exists.
- [ ] No sensitive data in views.

## Performance

- [ ] Lists use pagination.
- [ ] Read-only queries use AsNoTracking.
- [ ] Avoid unnecessary Include.
- [ ] Avoid loading all orders into memory before filtering.

## Final

- [ ] `dotnet build` passes.
- [ ] Manual test scenarios pass.
