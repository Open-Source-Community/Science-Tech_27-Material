# Git & GitHub Essentials: Beginner's Guide

A step-by-step guide for committee members. By the end you will be able to install Git, create a GitHub account, and save and upload your project.

---

## Session Slides

Follow along with the session slides on Canva:

[Open the Canva slides](https://canva.link/plamdisfpx2zh81)

---

## Start Here: Setup Checklist

Do these three steps **in order** before reading the rest of the guide.

### Step 1: Install Git

| Your system | Download / Instructions | Video tutorial |
|---|---|---|
| **Windows** | [Download Git for Windows](https://git-scm.com/download/win) | [Watch: Install Git on Windows](https://www.youtube.com/watch?v=TT8ktVp5j-k) |
| **Linux** | [Official Linux instructions](https://git-scm.com/download/linux) | [Watch: Install Git on Linux](https://www.youtube.com/watch?v=bGKmVpraFoQ) |

> **Windows tip:** The installer's default options are fine. Just keep clicking **Next**, then **Install**. It also installs **Git Bash**, the terminal we use in this guide.
>
> **Linux tip:** You do not need the video if you only want the command. On Ubuntu/Debian, open a terminal and run `sudo apt update && sudo apt install git`. On Fedora, run `sudo dnf install git`.

**Check that it worked.** Open **Git Bash** (Windows) or the **Terminal** (Linux) and type:

```bash
git --version
```

You should see something like `git version 2.47.0`. If you do, Git is installed.

### Step 2: Create a GitHub Account

- **Video:** [Watch: How to create a GitHub account](https://www.youtube.com/watch?v=atugUyFd1eY)
- **Sign up page:** [github.com/signup](https://github.com/signup)
- **Official guide:** [Creating an account on GitHub](https://docs.github.com/en/get-started/start-your-journey/creating-an-account-on-github)

> **Remember the email address you sign up with.** You will need that exact email in Step 3.

### Step 3: Configure Git (First Time Only)

Git stamps every change you make with your **name** and **email**. You set them once on each computer.

Open Git Bash (Windows) or Terminal (Linux) and run these commands. Replace the example values with your own.

```bash
# 1. Set your name (shown on every commit)
git config --global user.name "Your Name"

# 2. Set your email (MUST be the same email you used for GitHub)
git config --global user.email "your-email@example.com"

# 3. Check that everything was saved
git config --list
```

> Using the same email as your GitHub account lets GitHub link your work to your profile and show it on your contribution graph.

---

## Now Let's Understand It All

### 1. Why Do We Need Git & GitHub?

**The everyday problem.** Many people save endless copies of a project folder:

```
GraduationProject_v1
GraduationProject_Final
GraduationProject_Final_REAL
```

Without version control, it is chaotic to track changes, go back to an older version, or share code with a team.

**What is version control?** Think of it as a **time machine for your code**. It records **who** changed something, **when**, and **why**. Instead of many copies, you keep **one project with its full history**.

### 2. Git vs. GitHub: They Are Not the Same

| | Git | GitHub |
|---|---|---|
| **What is it?** | The local engine installed on your computer | A website (cloud platform) |
| **What does it do?** | Tracks your project history offline, inside a hidden `.git` folder | Backs up repositories, shares them with teammates, and builds your developer portfolio |
| **Needs internet?** | No | Yes |

### 3. The Three Core Areas

Every Git project has three areas. Understanding them is the key to everything else.

| Area | What it is | Command to move into it |
|---|---|---|
| **Working Directory** | The folder where you edit your files | (you work here) |
| **Staging Area** | Where you choose which changes to include in the next save | `git add` |
| **Local Repository** | Where a snapshot is permanently saved on your computer | `git commit` |

**The full flow of your work:**

```
Working Folder
   │  git add
   ▼
Staging Area
   │  git commit
   ▼
Local Repo (.git)
   │  git push
   ▼
GitHub Cloud
```

> **Easy way to remember it:** Saving takes two steps. First you **choose what goes into the box** (`add`), then you **seal and label the box** (`commit`).

---

### 4. Starting a Repository

A **repository** (or **repo**) is a project folder whose history is tracked by Git. For example, a folder called `my-portfolio/` with a hidden `.git` folder inside it.

There are two ways to get a repo on your computer:

#### Scenario A: Local First (you already have a folder)

Use `git init` to create the hidden `.git` folder and start tracking.

```bash
mkdir my-portfolio
cd my-portfolio
git init
# Output: Initialized empty Git repository in C:/Users/Basma/my-portfolio/.git/
```

#### Scenario B: Cloud First (the project already exists on GitHub)

Use `git clone <url>` to download a full copy. The link to GitHub is kept.

```bash
git clone https://github.com/username/project-name.git
cd project-name
```

> **Where do I get the URL?** On the repository page on GitHub, click the green **Code** button and copy the **HTTPS** link.

---

### 5. The Daily Save Workflow

| Command | What it does |
|---|---|
| `git status` | Shows which files are **untracked** (red), **staged** (green), or **clean** |
| `git add <file>` or `git add .` | Moves changes into the Staging Area (`.` means "everything") |
| `git commit -m "message"` | Saves a snapshot in your local history with a short explanation |
| `git log --oneline` | Shows the commit history in a short form |

**Example from start to finish:**

```bash
# Create a file
touch hello.txt

# See what Git notices
git status
# Untracked files (red): hello.txt

# Stage everything
git add .

git status
# Changes to be committed (green)

# Save the snapshot
git commit -m "Add hello file"
# [main (root-commit) 7f3a1c2] Add hello file
# 1 file changed, 0 insertions(+)

# View history
git log --oneline
# 7f3a1c2 (HEAD -> main) Add hello file
```

> **Write good commit messages.** Short and clear, saying what changed. For example, `Add hello file` is good, and `stuff` is not.

---

### 6. A Tour of Your GitHub Account

- **Profile and contribution graph:** your bio, pinned repositories, and the green squares that show your daily commits.
- **Repositories tab:** *public* repositories are visible to anyone, and *private* repositories are visible only to you and people you invite.
- **Creating a new repository:** click **+** then **New repository**. Give it a name and choose **Public** or **Private**.
  - If you are uploading an **existing local project**, leave **"Add a README"** **unchecked**.
- **Inside a repository:** the **Code** tab, the commit history, the green **Code** button (with the clone URL), and **Settings → Collaborators** (to invite teammates).

> GitHub is both a cloud storage hub for your code **and** a technical resume for developers.

---

### 7. From Git Bash to GitHub: Push and Pull

**The problem:** commits you make on your laptop live **only on your laptop**. Until you **push**, the repository on GitHub is still empty.

**The plan:** clone the project from GitHub, push your commits, and later pull online changes back down.

#### First-time setup (clone the repository)

```bash
# Download a full copy of the repository from GitHub (the link to GitHub is kept)
git clone https://github.com/username/my-portfolio.git

# Go into the project folder
cd my-portfolio
```

> On Windows, the first push opens the **Git Credential Manager**, a browser window where you sign in to GitHub. This is normal.

#### Later updates (add → commit → push)

```bash
git add .
git commit -m "Update portfolio title"
git push
```

#### Bringing online changes down

For example, after someone edits `README.md` directly on GitHub:

```bash
git pull
# Updating 7f3a1c2..9b4e8d1
# Fast-forward
# README.md | 2 ++
```

### The Golden Rule

> **Run `git pull` BEFORE you start coding each day.**
> **Run `git push` when you finish a task.**

---

## Quick Reference Cheat Sheet

| Command | What it does |
|---|---|
| `git --version` | Confirms Git is installed |
| `git config --global user.name "Name"` | Sets your display name for all repositories |
| `git config --global user.email "email"` | Sets your email (same as your GitHub email) |
| `git config --list` | Shows your current configuration |
| `git init` | Creates a hidden `.git` folder and starts tracking a local folder |
| `git clone <url>` | Downloads a full copy of a GitHub repo and keeps the link |
| `git status` | Shows untracked (red), staged (green), or clean files |
| `git add .` | Moves all changes into the Staging Area |
| `git commit -m "message"` | Saves a snapshot in local history |
| `git log --oneline` | Shows the commit history in short form |
| `git remote add origin <url>` | Saves the GitHub URL under the nickname `origin` |
| `git branch -M main` | Names the local branch `main` |
| `git push -u origin main` | Uploads local commits to GitHub (first time) |
| `git push` | Uploads new commits to GitHub |
| `git pull` | Downloads new commits from GitHub |
