# Clinic Management System  

A comprehensive Clinic Management System built using **ASP.NET MVC, Entity Framework, and SQL Server**. This system streamlines clinic operations, including patient management, appointment scheduling, prescriptions, and medical records with secure role-based access.

---

## Features  

### Core Functionalities  
- **Patient Management** – Add, update, and manage patient details.  
- **Appointment Scheduling** – Book, track, and manage appointments.  
- **Prescription Management** – Generate and manage patient prescriptions.  
- **Medical Records** – Securely store and retrieve patient history.  

### Security & Access  
- **Role-Based Access Control (RBAC)**  
  - **Admin**: Full system control  
  - **Doctor**: Manage appointments & prescriptions  
  - **Nurse**: View patient records  
  - **Patient**: Book appointments & view prescriptions  

### User Experience  
- **Multi-Language Support** – English & Arabic localization  
- **Responsive UI** – Bootstrap-powered for all devices  
- **Admin Dashboard** – Real-time analytics & reporting  

---

## Technologies  

| Category       | Technologies |  
|----------------|--------------|  
| Frontend       | ASP.NET MVC, Bootstrap 5, JavaScript |  
| Backend        | ASP.NET Core, Entity Framework Core |  
| Database       | SQL Server |  
| Authentication | ASP.NET Identity |  
| Architecture   | 3-Layer (Presentation, Business Logic, Data Access) |  
| Deployment     | MonsterASP.NET (CI/CD via GitHub Actions) |  

---

## Live Demo  

[Access Live Demo](https://ayadtytest.runasp.net/)  

### Test Accounts  
| Role      | Username      | Password |  
|-----------|--------------|----------|  
| Patient   | `01205397285` | `123456` |  
| Admin     | `01200000000` | `123456` |  

---

## Installation  

### Prerequisites  
- .NET 8 SDK  
- SQL Server  
- Visual Studio 2022 (Recommended)  

### Setup Steps  
1. **Clone the Repository**  
   ```bash
   git clone https://github.com/your-username/clinic-management-system.git
   cd clinic-management-system
   ```
