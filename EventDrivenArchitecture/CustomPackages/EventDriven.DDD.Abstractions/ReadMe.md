# EventDriven.DDD.Abstractions

Abstractions for implementing Domain Driven Design in .NET.

## Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download) (6.0 or greater)

## Packages
- [EventDriven.DDD.Abstractions](https://www.nuget.org/packages/EventDriven.DDD.Abstractions)

## Introduction

[Domain Driven Design](https://en.wikipedia.org/wiki/Domain-driven_design) (DDD) is a software design approach focusing on modelling software to match a domain according to input from domain experts.


The **EventDriven.DDD.Abstractions** library contains interfaces and abstract base classes to support these concepts:
- **Entity**: A type that has an identity with behavior and state that can change over time.
- **Event**: A statement of fact about what change has been made to the domain state.

### Reference Architecture and Development Guide

Please refer to the [EventDriven.ReferenceArchitecture](https://github.com/event-driven-dotnet/EventDriven.ReferenceArchitecture) repository for a reference architecture and development guide based on the principles of Domain Driven Design (DDD), Command Query Responsibility Segregation (CQRS) and Event Driven Architecture (EDA).