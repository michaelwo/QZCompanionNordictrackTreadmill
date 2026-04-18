---
description: Two-pass Clean Code review — static checks + AI analysis against Uncle Bob's full checklist
---

Perform a Clean Code smell review. If an argument is provided, review that file or directory.
If no argument is provided, review Java files changed since the last commit.

## Step 1 — Determine scope

```bash
# No argument: files changed vs last commit
git diff --name-only HEAD -- '*.java'
```

If the above returns nothing (clean working tree), use the files from the last commit:
```bash
git show --name-only --format='' HEAD -- '*.java'
```

If an argument was given (e.g. `/smells device/catalog/X32iDevice.java` or `/smells all`):
- Specific file/dir: use that path under `app/src/main/java/`
- `all`: use the entire `app/src/main/java/` tree

Announce the scope before proceeding: "Reviewing N file(s): ..."

---

## Step 2 — Pass 1: Static checks

Run each check below as a bash command against the files in scope.
Collect all findings; do not stop on first hit.

### 2a. Flag arguments
Boolean literals passed directly as method arguments. Uncle Bob: "Flag arguments are ugly. Passing a boolean into a function is truly terrible practice."

```bash
grep -n "(true)\|(false)\|, true)\|, false)\|, true,\|, false," <files> | grep -v "^\s*//"
```

Exclude: variable assignments (`= true`, `= false`), return statements (`return true`), annotations.

### 2b. Commented-out code
Lines that are comments but contain code syntax.

```bash
grep -n "^\s*//.*[;{}()]" <files> | grep -v "^\s*// *[A-Z]" | grep -v "^\s*//\s*$"
```

Heuristic: a comment line containing `;`, `{`, `}`, or `()` is likely commented-out code.
False positives allowed — use judgment when reporting.

### 2c. Magic numbers
Numeric literals that are not 0, 1, 2, -1, or 100 and appear outside a `static final` constant declaration.

```bash
grep -n "[^a-zA-Z_0-9\"'@]\d\{3,\}\|[^a-zA-Z_0-9\"'@]\d\+\.\d\+" <files> | grep -v "static final"
```

**Special rule for this project:** Numeric constants in `device/catalog/` files represent
calibrated hardware coordinates derived from physical measurement. Flag them as
**"formula constant — auditability debt (tracked in maturity model)"**, not as a generic
magic number smell. Still report them, but classify separately.

### 2d. Closing-brace comments
```bash
grep -n "//\s*end\b\|//\s*}\|// end if\|// end for\|// end while" <files>
```

### 2e. Negative conditionals
`if (!condition)` when a positive form is possible. Uncle Bob: "Negatives are slightly harder to understand than positives."

```bash
grep -n "if\s*(!)" <files>
```

Also flag double-negatives: `!is`, `!has`, `!can` patterns.

### 2f. Lines over 120 characters
```bash
awk 'length > 120 {print FILENAME":"NR": "length" chars"}' <files>
```

### 2g. Long parameter lists
Methods with more than 3 parameters. Uncle Bob: "The ideal number of arguments for a function is zero. [...] More than three requires very special justification."

```bash
grep -n "^\s*\(public\|private\|protected\)\s.*\s\w\+\s*(" <files> | \
  awk -F'(' '{print NR": "$0}' | grep -v "^[^(]*$"
```

Use judgment: count commas inside the first `(...)` block. Flag methods with ≥ 3 commas (4+ params).

---

## Step 3 — Pass 2: AI review

Read each file in scope. For each category below, identify specific violations with
`filename:line` references. Be concrete — quote the offending line. Do not invent issues.
If a category is clean, say "None found."

### General Rules
- Is complexity being reduced, or is there unnecessary indirection?
- Boy Scout Rule: does recent code leave its surroundings cleaner?

### Design
- **Prefer polymorphism to if/else or switch/case**: Are there if/else chains that test a type
  or mode that could be a virtual method dispatch? (In this codebase, device-specific behavior
  inside a shared dispatch loop is the primary risk.)
- **Law of Demeter**: Does any method reach through object chains (`a.getB().getC().doX()`)?
- **Dependency injection**: Are dependencies constructed inside methods rather than passed in?
- **Configurable data at high levels**: Are constants that represent tunable behavior buried
  deep in implementation code?

### Names
- Are names descriptive and unambiguous? Flag single-letter variables outside loop counters.
- Are there names that use encodings or type prefixes (Hungarian notation)?
- Are boolean variable/method names positive (not `notDone`, `isNotValid`)?
- Are magic-number fields given searchable names?

### Functions
- **Single Responsibility**: Does each method do exactly one thing? Flag methods that contain
  multiple levels of abstraction mixed together.
- **Side effects**: Does a method do something beyond what its name implies?
- **Output arguments**: Does any method modify a parameter that was passed in?
- Flag any method body over 20 lines as a candidate for extraction.

### Comments
- Are there comments that explain *what* the code does (redundant with the code itself)?
- Are there commented-out code blocks? (Cross-reference Pass 1 findings.)
- Are there TODO/FIXME comments without an owner or ticket?
- Are comments present that explain *why* — intent, constraint, or consequence? (Good — note these.)

### Objects and Data Structures
- **Hybrid structures**: Is any class both a data holder (public fields) and a behavior provider
  (complex methods)? These should be one or the other.
- **Small classes**: Flag any class over 200 lines as a candidate for splitting.
- **Base/derivative coupling**: Does any parent class reference a subclass by name?
- **Behavior-selection parameters**: Are there parameters whose sole job is to select
  a code path (flag arguments, mode enums)? Cross-reference Pass 1 flag-argument findings.

### Code Smells (structural)
- **Rigidity**: Would changing one thing here require changes in many other places?
- **Needless repetition**: Is the same logic duplicated in two or more places?
- **Needless complexity**: Is there code that solves a problem that doesn't exist yet?
- **Opacity**: Are there sections that are hard to read at a glance? Why?

---

## Step 4 — Report

Output the following report. Do not pad findings — if something is clean, say so.

```
## Clean Code Review — <scope> (<N> file(s))

### Pass 1: Static Checks

| Check                  | Findings |
|------------------------|----------|
| Flag arguments         | <file:line — description, or "None"> |
| Commented-out code     | <...> |
| Magic numbers          | <...> |
| Formula constants      | <count> in device/catalog/ — auditability debt, not blocking |
| Closing-brace comments | <...> |
| Negative conditionals  | <...> |
| Lines >120 chars       | <...> |
| Long parameter lists   | <...> |

### Pass 2: AI Review

**Design**
- <finding: file:line — explanation> OR "None found"

**Names**
- <...>

**Functions**
- <...>

**Comments**
- <...>

**Objects & Data Structures**
- <...>

**Code Smells**
- <...>

---

### Verdict

Critical (must fix before commit):
- <list — or "None">

Advisory (consider fixing):
- <list — or "None">

Formula constant debt: <N items — addressed separately via maturity model>
```

**Critical** smells are those that Uncle Bob classifies as always wrong: flag arguments,
commented-out code (not formula constants), base/derivative coupling violations, hybrid structures
with public mutable fields and complex behavior, Law of Demeter violations in dispatch paths.

**Advisory** smells are judgment calls: long methods, negative conditionals, missing named constants
for non-formula values, naming issues, TODO comments.

When invoked from `/ship`, report Critical smells to the user and **stop the commit** until they
are resolved. Advisory smells appear in the `/ship` preview but do not block.
