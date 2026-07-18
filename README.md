# Habit Tracker — CSE325 Group Project

## Team Members

- Treasure Tambwanaye — sole active member as of W02

A .NET 8 Blazor Web App (Interactive Server) with ASP.NET Core Identity
authentication and CRUD habit tracking.

## What's included

- **Auth**: ASP.NET Core Identity (register/login/manage account) — scaffolded
  by `dotnet new blazor -au Individual`
- **Data model**:
  - `Habit` — Name, Description, Frequency (Daily/Weekly), owned by a user
  - `HabitEntry` — a daily check-in record (Date + Completed) tied to a Habit
- **Pages**:
  - `/` — landing page
  - `/dashboard` — list your habits, check off today, see current streak
  - `/habits/new` and `/habits/edit/{id}` — add/edit a habit
  - `/habits/{id}` — 14-day history view for one habit
  - `/Account/*` — Identity's built-in register/login/manage pages

## First-time setup (run this on your machine — needs real internet access
for NuGet, which this build environment didn't have)

```bash
cd HabitTracker
dotnet restore
```

### Create the database

This project uses EF Core migrations. The Identity schema migration is
already included, but you need to add one for the new `Habit`/`HabitEntry`
tables and then apply everything:

```bash
dotnet tool install --global dotnet-ef   # if you don't already have it
dotnet ef migrations add AddHabitTables
dotnet ef database update
```

This creates a local SQLite file (`Data/app.db` — it's gitignored, so
everyone on the team gets their own local copy).

### Run it

```bash
dotnet run
```

Open the URL shown in the console (something like `https://localhost:5001`),
register a new account, and start adding habits.

## Notes for the team

- Render mode is **Interactive Server** — no separate API/JS build step needed.
- Each user only ever sees their own habits (`Habit.UserId` is checked on every
  query), so there's no cross-user data exposure to worry about.
- `HabitEntry` has a unique index on `(HabitId, Date)` — one check-in per
  habit per day.
- Next steps: styling/branding pass, accessibility check (Lighthouse / WCAG
  2.1 AA), deploy to a cloud host (Azure App Service free tier is a common
  choice), write user documentation, record the group demo video.
