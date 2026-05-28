# Setup Instructions

Before launching the application, you need to configure both the backend and frontend environment settings.

**1. Backend Configuration**

Navigate to:

`ToDoApi\ToDoApi.Api\appsettings.json`

Inside this file, update the following values:

```json
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_DEFAULT_CONNECTION_STRING"
  },
  "AppSettings": {
    "Token": "YOUR_SUPER_SECRET_KEY_FOR_JWT",
    "FrontedUrl": "YOUR_FRONTEND_URL"
  }
```

**2. Frontend Configuration**

Navigate to:

`To-Do-client\src\environments\environment.ts`  
`To-Do-client\src\environments\environment.development.ts`

Update the API base URL in both files:

Example:

```ts
export const environment = {
  apiBaseUrl: "YOUR_API_BASE_URL",
};
```
