# GPT-5.5 Code Review Prompt

```text
You are reviewing an ASP.NET Core MVC project for correctness and maintainability.

Focus on:
- Build errors
- Runtime errors
- EF Core query correctness
- MVC routing
- ViewModels
- Validation
- Authentication and authorization
- Anti-forgery tokens
- Clean controller actions
- Clear user messages

Do not add new features outside plan.md.
Return a prioritized list of fixes and then implement the smallest safe fix set.
Run dotnet build after changes.
```
