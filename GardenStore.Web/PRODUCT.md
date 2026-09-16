# Product

<!-- impeccable:product-schema 1 -->

## Platform

web

## Stack

Inferred from the assignment: ASP.NET Core MVC on .NET 8, Razor views, Bootstrap 5, and local static assets. The project is delivered as a Visual Studio solution.

## Users

Inferred: a shopper browsing a small demonstration catalog on desktop or mobile. A secondary audience is the instructor evaluating the practical work against the supplied PDF.

## Product Purpose

Provide a complete educational garden-goods storefront where a visitor can filter products, add available items to a session cart, review totals, and confirm an order. Success means every required Bootstrap component and ASP.NET Core static-file behavior is visible and functional.

## Operating Context

The project is opened in Visual Studio, run locally, and evaluated through its catalog and cart routes. Product and order data are illustrative and live only in application memory or the browser session.

## Capabilities and Constraints

- Required: responsive Bootstrap navbar, grid, cards, alerts, modal, static files, environment-aware assets, bundling and minification.
- Required: one card per row on phones, two on tablets, and three on desktops.
- Included for the highest grade: price comparison, tag filters, dynamic stock/hit/discount states, and small client-side filter feedback.
- No database, authentication, payment, or external service is required.
- Product theme is inferred because the brief did not specify one: practical goods for the garden and home.

## Evidence on Hand

The source requirements are in `C:\Users\e8351\Downloads\Практическая работа2.pdf`. No logo, product photography, commercial claims, or production data were supplied; the catalog content is explicitly demonstrative.

## Product Principles

- Demonstrate each assignment requirement with working behavior, not decorative placeholders.
- Keep the shopping flow understandable without instructions.
- Work fully offline after package restore by shipping Bootstrap and product artwork locally.
- Preserve accessible labels, keyboard focus, responsive layout, and clear empty/error states.
