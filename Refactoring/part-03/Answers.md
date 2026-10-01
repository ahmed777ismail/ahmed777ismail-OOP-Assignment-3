# Part 03 - answers

## BlockedUsers
- Time complexity before: **O(B x R)**.
- Time (ms) before: **19 ms** (50,000 blocked IDs, 5,000 requests, seed 42; found 5,000).
- What changed: build a `HashSet<int>` once and use average O(1) membership checks.
- Time complexity after: **O(B + R)** average time and O(B) extra memory.
- Time (ms) after: **1 ms** on the same machine and dataset; found remains 5,000.

## Students
- **Problem:** A list eagerly created one million objects although only three were used.
- **Change:** `IEnumerable<Student>` plus `yield return` creates only requested students.
