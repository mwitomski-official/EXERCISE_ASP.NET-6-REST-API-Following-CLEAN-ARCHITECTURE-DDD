# Buber Dinner API

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Test",
  "lastname": "Test",
  "email": "test@test.com",
  "password": "Test!1@2@3!"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "d519da74-6216-11ed-9b6a-0242ac120002",
  "firstName": "Test",
  "lastname": "Test",
  "email": "test@test.com",
  "token": "eyJhb..0242ac120002"
}
```

## Login

### Login Requests

```js
POST {{host}}/auth/login
```

```json
{
  "email": "test@test.com",
  "password": "Test!1@2@3!"
}
```

### Login Response

```js
200 OK
```

```json
{
  "id": "d519da74-6216-11ed-9b6a-0242ac120002",
  "firstName": "Test",
  "lastname": "Test",
  "email": "test@test.com",
  "token": "eyJhb..0242ac120002"
}
```
