# Order Processing Application Assignment

## Assignment Overview

Imagine you’re writing an order processing application for a large company. In the past, this company used a fairly random mixture of manual and ad-hoc automated business practices to handle orders; they now want to put all these various ways of handling orders together into one system: your application.

After a full day of workshops, the following set of rules need to be managed by the new system:

### Business Rules

1. **Physical Product**: If the payment is for a physical product, generate a packing slip for shipping.
2. **Book**: If the payment is for a book, create a duplicate packing slip for the royalty department.
3. **Membership**: If the payment is for a membership, activate that membership.
4. **Membership Upgrade**: If the payment is an upgrade to a membership, apply the upgrade.
5. **Membership Notification**: If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade.
6. **Video - “Learning to Ski”**: If the payment is for the video “Learning to Ski,” add a free “First Aid” video to the packing slip (the result of a court decision in 1997).
7. **Agent Commission**: If the payment is for a physical product or a book, generate a commission payment to the agent.

**Note:**  
Design a new system which can handle these rules and is open to extension for new rules.

---

## Design Guidelines

- Use principles of clean code and object-oriented design.
- The system should be easy to extend with new rules without modifying existing code (consider using a pattern like Strategy, Command, or Chain of Responsibility).
- Write clear, maintainable, and well-documented code.

## Suggested Structure

- `src/` – Source code for the application  
- `tests/` – Unit tests and test data  
- `README.md` – Assignment overview and instructions (this file)

## Getting Started

1. Clone this repository.
2. Implement the order processing logic according to the rules above.
3. Write unit tests for your implementation.
4. Update the documentation as needed.

## Example Usage

```
# Example (to be replaced with real code and usage instructions)
order = Order(product_type="book", ...)
process_order(order)
```

## License

This assignment is for educational purposes.
