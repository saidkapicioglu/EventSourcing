# 🧪 Event Sourcing & CQRS Example with Ad Management System

This repository contains a simple implementation of **Event Sourcing** and **CQRS** (Command Query Responsibility Segregation) using a basic ad (listing) management system. The goal is to demonstrate how these two architectural patterns work together to provide a scalable, traceable, and decoupled system.

---

## 📚 What You Will Learn

- What is **Event Sourcing** and why it's useful  
- How **CQRS** separates command (write) and query (read) responsibilities  
- How to model a system where every change is stored as an immutable event  
- How to replay events to build application state  
- How commands, events, and projections interact in a real-world inspired example

---

## 🧱 Architecture Overview

### Components:

- `Ad`: Domain entity representing a classified ad  
- `CreateAdCommand`, `ChangePriceCommand`: Commands to mutate the system  
- `AdCreatedEvent`, `PriceChangedEvent`: Domain events triggered by commands  
- `EventBroker`: Central mediator to dispatch commands and record events  
- `Query Handlers`: Provide read access via separate models  
- `AdSource`: In-memory event store for demo purposes

---

## ▶️ How It Works

1. Commands are issued (e.g. create ad, change price)
2. Domain logic creates one or more **events**
3. Events are stored in a **simple event log**
4. Read models are updated from these events
5. Users can query the current state or full history

---

## 🛠️ Run Example

```bash
# Simply run the Program.cs in a C# console project
dotnet run
