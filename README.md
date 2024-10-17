
# Medical Practice Web Application

This is a web-based application developed for managing patient visits in a medical practice. The application supports role-based authentication and different functionalities for administrators, doctors, and assistants.

## Technologies Used
- **Backend**: ASP.NET Core 6.0 (C#)
- **Frontend**: React with React-Bootstrap
- **Database**: MSSQL Server

## Features
- **Role-based Authentication**: Separate access for Admin, Doctor, and Assistant roles.
- **Patient Management**: CRUD operations for managing patient data.
- **Appointment Scheduling**: Allows doctors to view and manage appointments.
- **Assistant Management**: Assistants can be added and managed by the admin.

## Backend Setup (ASP.NET Core)

### Prerequisites
- .NET 6.0 SDK
- MSSQL Server

### Clone the Repository:

```bash
git clone https://github.com/your-repo/medical-practice-backend.git
```

### Navigate to the Project Folder:

```bash
cd medical-practice-backend
```

### Configure Database:

Ensure to have the correct connection string in `appsettings.json` under `ConnectionStrings`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=MedicalPracticeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### Run Migrations:

```bash
dotnet ef database update
```

### Run the API:

```bash
dotnet run
```

The API should now be running on `http://localhost:5208`.

## Frontend Setup (React)

### Prerequisites
- Node.js (v16 or above)
- npm (v7 or above)

### Clone the Repository:

```bash
git clone https://github.com/your-repo/medical-practice-frontend.git
```

### Navigate to the Frontend Folder:

```bash
cd medical-practice-frontend
```

### Install Dependencies:

```bash
npm install
```

### Run the Frontend:

```bash
npm start
```

The frontend should now be running on `http://localhost:3000`.

### Environment Variables

#### Backend:
Ensure to have the correct database connection string in `appsettings.json`.

#### Frontend:
If your backend API runs on a different URL, configure the `API_URL` in your React app's `.env` file:

```bash
REACT_APP_API_URL=http://localhost:5208/api
```

## Usage

Once both the backend and frontend are running, you can access the application on `http://localhost:3000`. Use the following credentials to log in:

- **Admin**: 
  - Email: `admin@example.com`
  - Password: `admin@123`
  
- **Doctor**: 
  - Email: `doctor@example.com`
  - Password: `doctor@123`
  
- **Assistant**: 
  - Email: `assistant@example.com`
  - Password: `assistant@123`

## API Documentation

### Authentication

#### POST `/api/Auth/login`

**Request Body:**

```json
{
  "email": "user@example.com",
  "password": "password123"
}
```

**Response**: JWT token if login is successful.

### Patients

#### GET `/api/Patient`

Retrieves a list of patients.

#### POST `/api/Patient`

Adds a new patient.

**Request Body:**

```json
{
  "name": "John",
  "surname": "Doe",
  "email": "john.doe@example.com",
  "phoneNumber": "1234567890"
}
```

### Assistants

#### POST `/api/Assistant/addAssistant`

Adds a new assistant.

**Example Request Body:**

```json
{
  "name": "Jane",
  "surname": "Doe",
  "username": "janedoe",
  "password": "assistant@123"
}
```

## Contributing

Contributions are welcome! Please open a pull request or create an issue to discuss changes. Follow these steps to contribute:

1. Fork the repository.
2. Create a new feature branch: `git checkout -b feature/your-feature`.
3. Commit your changes: `git commit -m 'Add some feature'`.
4. Push to the branch: `git push origin feature/your-feature`.
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
