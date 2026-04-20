---
description: Run local tests, update docs, preview commit, wait for confirmation, commit, push to fork, and trigger CI build
---

Prepare and ship a commit to michaelwo's fork. Follow these steps exactly.

## Step 1 — Run local unit tests

Run the project test script (covers all pure-JVM tests; excludes Robolectric):

```bash
bash run-tests.sh 2>&1
```

**If any test fails, stop here.** Report the failures and do not proceed to commit.

## Step 1.5 — Clean Code smell check

Perform the same two-pass review defined in `/smells`, scoped to the Java files changed
since the last commit (`git diff --name-only HEAD -- '*.java'`).

**Critical smells block the commit.** Report them and stop. Do not proceed to Step 2 until
the user resolves them or explicitly overrides ("ship anyway").

Critical smells (always blocking):
- Flag arguments (boolean literals passed directly to a method)
- Commented-out code blocks
- Base class referencing a subclass by name
- Law of Demeter violations in the dispatch path
- Hybrid structures with public mutable fields and complex behavior

Advisory smells (reported in the Step 5 preview, do not block):
- Methods over 20 lines
- Negative conditionals
- Long parameter lists (≥ 4 params)
- Magic numbers outside `device/catalog/`
- TODO/FIXME without owner
- Naming issues

Formula constants in `device/catalog/` are auditability debt tracked in the maturity model —
note count only, do not block.

## Step 2 — Documentation review

Before staging, check whether the changes require doc updates. Run:

```bash
git diff --name-only HEAD
```

Then apply these rules based on what changed:

| Changed files | Docs to review |
|---------------|----------------|
| `device/catalog/*.java` (new file) | `docs/device-reference.md` — add the new device row |
| `device/catalog/*.java` (formula change) | `docs/device-reference.md` — update the formula entry |
| `reader/*.java` or `device/Device.java` / `BikeDevice.java` / `TreadmillDevice.java` | `docs/architecture.md` — check class descriptions, hierarchy diagram, call-site examples |
| Any `.java` change that affects a scored maturity dimension | `docs/maturity-model.md` — update the Current Scores table and Next Step rows |
| New project command or skill | `docs/` if a runbook or usage guide is affected |

For each doc that may be stale:
1. Read the current doc.
2. Read the relevant changed source files.
3. Update only the sections that are actually stale — do not rewrite sections that are still accurate.
4. If the maturity model score changes, update both the score and the date line (`as of YYYY-MM-DD`).

Include any updated docs in the staged files list (Step 4). If no docs need updating, state that explicitly.

## Step 3 — Inventory

Run all of these in parallel:
- `git status`
- `git diff`
- `git diff --cached`
- `git log --oneline -5`

## Step 4 — Stage

Stage only files relevant to the current task. Never use `git add -A` or `git add .`.
Never stage:
- `.env`, `*.jks`, `*.p12`, `*.keystore`, `signapk.sh` — may contain secrets
- `*.rtf`, `download-build.sh~` — scratch files
- `app/build/` — build artifacts

If it is ambiguous which files belong in this commit, ask before staging.

## Step 5 — Draft commit message

Write a conventional commit message:
- First line: `Type: short description` (≤72 chars). Type: `Feat`, `Fix`, `Refactor`, `Test`, `Docs`, `Chore`.
- Body (optional): explain WHY, not what.
- Trailer: `Co-Authored-By: Claude Sonnet 4.6 <noreply@anthropic.com>`

## Step 6 — Show preview and STOP

Present the following to the user and **do not proceed until they explicitly confirm**:

```
Tests: N passed, 0 failed ✓

Smells: <"None" | list advisory findings — critical findings would have already blocked>

Docs updated: <"None" | list of docs touched and what changed>

Files to commit:
  <list staged files>

Commit message:
  <full message>

Target: fork → michaelwo/QZCompanionNordictrackTreadmill  (<branch>)

Reply "yes" (or "go") to commit and push, or give corrections.
```

## Step 7 — Commit and push (only after confirmation)

```bash
git commit -m "..."
git push fork <branch>
```

**CRITICAL: always push to `fork`, never `origin`.**
- `fork` = michaelwo/QZCompanionNordictrackTreadmill ✓
- `origin` = cagnulein/QZCompanionNordictrackTreadmill ✗ (upstream — never push here)

After pushing, confirm the remote URL in the push output contains `michaelwo/`.

## Step 8 — Trigger CI build

After a successful push, trigger a build on the fork:

```bash
gh workflow run main.yml \
  --repo michaelwo/QZCompanionNordictrackTreadmill \
  --ref <branch>
```

Then confirm it started:

```bash
gh run list --repo michaelwo/QZCompanionNordictrackTreadmill --limit 3
```

Report the run URL to the user so they can monitor it. If `gh workflow run` fails because
Actions are disabled on the fork or the workflow file is not on the branch, report the error
and note that a build can be triggered manually from
github.com/michaelwo/QZCompanionNordictrackTreadmill/actions.
