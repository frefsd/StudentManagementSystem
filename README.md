# 🎓 学生管理系统（Student Management System）

![.NET](https://img.shields.io/badge/.NET-Windows%20Forms-blue)
![C#](https://img.shields.io/badge/Language-C%23-green)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

> 一个基于 C# 和 Windows Forms 的学生信息管理系统，支持增删改查、分页显示与数据筛选，适合 .NET 初学者学习 CRUD 操作、UI 设计与数据库交互。

本系统使用 **Entity Framework Core** 作为 ORM 框架，与 **SQL Server** 数据库进行交互，界面采用现代化设计风格，具备良好的用户体验。

---

## 📋 功能特性

- ✅ **用户登录验证**：支持默认用户名密码登录，可选择“记住我”自动登录。
- ✅ **学生信息管理**：
  - 添加新学生
  - 编辑现有学生信息
  - 删除学生记录
  - 查看所有学生列表并支持分页浏览
- ✅ **智能数据筛选**：支持按班级、院系或关键字（姓名/学号）快速搜索。
- ✅ **美观的 UI 界面**：采用渐变背景、圆角控件、自定义按钮样式，提升视觉体验。
- ✅ **数据持久化**：所有操作均保存至 SQL Server 数据库，重启不丢失。

---

## ⚙️ 技术栈

| 类别 | 技术 |
|------|------|
| 开发语言 | C# |
| 开发框架 | Windows Forms (.NET) |
| 数据访问 | Entity Framework Core |
| 数据库 | Microsoft SQL Server |
| 开发工具 | Visual Studio, SSMS |

---

## 📥 如何运行本项目

### 1. 克隆项目到本地

```bash
git clone https://github.com/frefsd/StudentManagementSystem.git
cd StudentManagementSystem
