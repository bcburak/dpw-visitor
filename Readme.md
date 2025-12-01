# DpWorld Visitor Entrance System

This project is a Visitor Entrance application designed to manage visitor check-ins at DP World facilities. It consists of a .NET 9 Web API backend and an Angular frontend.

## 🚀 Getting Started

### Prerequisites
*   **.NET 9 SDK**
*   **Node.js** (LTS version recommended)
*   **Angular CLI**

### 📥 Cloning and Setup

1.  **Clone the repository**:
    ```bash
    git clone https://github.com/bcburak/dpw-visitor.git
    cd dpworld
    ```

### 🖥️ Backend (.NET API)

The backend follows the **Onion Architecture** (Domain, Application, Infrastructure, API).

1.  **Navigate to the root directory** (where `DpWorld.Visitor.sln` is located).
2.  **Restore dependencies**:
    ```bash
    dotnet restore
    ```
3.  **Run the API**:
    ```bash
    dotnet run --project DpWorld.Visitor.Api
    ```    
    *   Swagger UI is available at `http://localhost:5298/swagger` (depends on your port) for testing endpoints.

### 🌐 Frontend (Angular App)

The frontend is a modern Angular application located in the `dpworld-visitor-client/dpworld-visitor-app` folder.(Located client app to use just one repo for the assignment implementation)

1.  **Navigate to the frontend directory**:
    ```bash
    cd visitor-reg-app
    ```
2.  **Install dependencies**:
    ```bash
    npm install
    ```
3.  **Run the application**:
    ```bash
    ng serve
    ```
    *   Open your browser and navigate to related local webhost.

---

## 🏗️ Implementation Overview

### Backend Structure
*   **DpWorld.Visitor.Domain**: Core entities (`Visitor`, `CheckIn`, `Entrance`) and interfaces.
*   **DpWorld.Visitor.Application**: Business logic, Use Cases (CQRS pattern with MediatR), and DTOs.
*   **DpWorld.Visitor.Infrastructure**: Implementation of interfaces (Repositories, Services). Currently uses an **In-Memory Database** for simplicity.
*   **DpWorld.Visitor.Api**: Controllers and API configuration.

### Frontend Flow
The Angular app implements a multi-step wizard for visitor registration:
1.  **Entrance Selection**: User enters or scans an Entrance ID (e.g., `MAIN-ENTRANCE`,`SIDE-ENTRANCE`).
2.  **Personal Details**: User provides Name, Company, and Email.
3.  **Team Selection**: User selects the internal team/host they are visiting.
4.  **Check-in Summary**: Review details and confirm check-in.
5.  **Success**: Confirmation screen.

---

## 🔮 Future Concepts & High-Level Design

### 1. Check-out Flow (High-Level)
The check-out process ensures we know when visitors leave the premises.

*   **Trigger**: User scans an "Exit QR Code" at a turnstile or exit door.
*   **Data Required**:
    *   `VisitorID` (from their badge/pass).
    *   `ExitEntranceID` (location of exit).
    *   `Timestamp`.
*   **Process**:
    1.  System validates the `VisitorID` has an active `CheckIn` record without a `CheckOutTime`.
    2.  System updates the record with `CheckOutTime` and `ExitEntranceID`.
    3.  **Metrics**: Allows calculation of "Time on Site".

### 2. Admin Capabilities (High-Level)
An Admin Portal would be required for security and facilities management.

*   **Dashboard**:
    *   Real-time counter of "Current Visitors on Site".
    *   List of current and past visitors.
*   **Visitor Log**:
    *   Searchable history of all visits (Date, Name, Host, Duration).
    *   Export to CSV/PDF for compliance and sharing feature.
*   **Configuration**:
    *   **Generate QR Codes**: Create printable QR codes for new Entrances (e.g., "Warehouse B Door").
    *   Manage Team/Host lists.

---

## 📝 Demo Notes & Missing Features

### Current Limitations (For Demo Purposes)
*   **Persistence**: The application currently uses an **In-Memory Database**. All data is lost when the backend application stops. For production, this should be swapped with MsSQL Server or PostgreSQL.
*   **Validation**: Basic validation is in place, but edge cases (e.g., duplicate check-ins for the same person) need more robust handling.

### What Could Be Added
*   **Authentication**: Admin portal needs secure authantication login (OAuth).
*   **Notifications**: Email/SMS to the Host when their visitor checks in.
*   **Logging**: To trace error/info logs.
*   **Unit Tests**: Expand `DpWorld.Visitor.Tests` to cover more edge cases in the Application layer.
