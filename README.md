# Root and Nodes Pattern

This is a framework for implementing a tree-like structure in C#. It consists of two main classes: Root and Node.

## Root

The `Root` class represents the root of the tree. It has the following responsibilities:

- Keeping a list of nodes that are owned by the root.
- Keeping track of the currently active node.
- Setting the start node for the tree.
- Running the tree by setting the active node to the start node and calling the `Entry` method on the start node.
- Passing input to the `OnKeyboard` method of the active node.
- Setting the active node to the next node in the tree, as determined by the output of the current node.

## Node

The `Node` class represents a node in the tree. It has the following responsibilities:

- Being able to connect to a child node.
- Keeping a list of possible outputs.
- Returning the child node corresponding to a given output.
- Implementing an `OnEntry` method that is called when the node is entered.
- Implementing an `OnKeyboard` method that is called when input is received.

## Usage

To use the framework, you will need to create your own classes that inherit from `Root` and `Node` and implement their abstract methods. You can then create an instance of your `Root` class and use the `SetStartNode` and `Run` methods to start the tree. Input can be passed to the `Root` instance using the `OnKeyboard` method.

## Root and Nodes Console Example

This is a console application demonstrating the usage of the `RootAndNodesPattern` library. The application displays a message, asks the user a question, and based on their answer, either prints a series of asterisks or displays another message. The user can then exit the application by pressing any key.



