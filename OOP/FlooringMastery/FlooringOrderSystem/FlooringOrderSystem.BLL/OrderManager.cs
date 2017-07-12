using System;
using FlooringOrderSystem.BLL.Helpers;
using System.Collections.Generic;
using FlooringOrderSystem.Models.Interfaces;
using FlooringOrderSystem.Models;
using FlooringOrderSystem.Models.Responses;
using FlooringOrderSystem.Data;

namespace FlooringOrderSystem.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private DisplayOrder _displayOrder = new DisplayOrder();
        private List<Order> _orders = new List<Order>();
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            //_orders = orderRepository.LoadAllOrders();
        }

        public OrderLookupResponse DisplayOrders(DateTime date)
        {
            OrderLookupResponse response = new OrderLookupResponse();
            _orders = _orderRepository.LoadAllOrders(date);
            foreach (var order in _orders)
            {
                _displayOrder.Show(order);

            }
            response.Success = true;
            return response;
        }
        public OrderLookupResponse LookupOrder(DateTime date, int orderNumber)
        {

            OrderLookupResponse response = new OrderLookupResponse();
            response.Order = _orderRepository.LoadOrder(date, orderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderNumber} is not a valid order!";
            }

            else
            {
                response.Success = true;
            }

            if (response.Success)
            {
                _displayOrder.Show(response.Order);
            }
            return response;
        }

        public OrderResponse AddOrder(DateTime date)
        {
            OrderResponse response = new OrderResponse();


            if (date < DateTime.Today)
            {
                response.Success = false;
                response.Message = $"{date} is not valid.  Please enter a future date.";
                return response;
            }

            else
            {
                response.Success = true;
            }
            Order order = new Order();
            order.OrderDate = date;

            order.OrderFileDate = date.ToString("MMddyyyy");

            do
            {
                Console.Write("Enter Customer Name: ");
                order.CustomerName = Console.ReadLine();

            } while (order.CustomerName == "");


            do
            {
                Console.Write("Enter State Abbreviation: ");
                order.State = Console.ReadLine().ToUpper();
            } while (order.State == "" || order.State.Length != 2);

            ReadTaxData readTax = new ReadTaxData();
            //check state.txt
            readTax.InRepo(order.State);
            if (!readTax.InRepo(order.State))
            {
                response.Message = "We do not sell in that state!";
                response.Success = false;
                return response;
            }

            else
            {
                Tax stateTax = new Tax();
                stateTax = readTax.StateTax(order.State);
                order.TaxRate = (stateTax.TaxRate / 100);
            }


            Product newProduct = new Product();
            do
            {
                //print list of products with foreach loop
                //DisplayProducts display = new DisplayProducts();
                //display.Show();
                FileProductRepository prodRepo = new FileProductRepository();
                prodRepo.DisplayProducts();
                //Console.Write("Enter a choice from the list above: ");
                //add validation
                newProduct = prodRepo.ChooseProduct();
                order.ProductType = newProduct.ProductType;
                order.CostPerSquareFoot = newProduct.CostPerSquareFoot;
                order.LaborCostPerSquareFoot = newProduct.LaborCostPerSquareFoot;

            } while (order.ProductType != newProduct.ProductType);


            while (order.Area <= 100)
            {
                decimal orderArea;
                Console.Write("Enter the area of the order in square feet (greater than 100 sqft): ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out orderArea))
                {
                    order.Area = orderArea;
                }
                
            }

            order.LaborCost = order.LaborCostPerSquareFoot * order.Area;
            order.MaterialCost = order.CostPerSquareFoot * order.Area;
            order.Tax = (order.LaborCost + order.MaterialCost) * order.TaxRate;
            order.Total = order.LaborCost + order.MaterialCost + order.Tax;

            response.Success = true;
            response.Order = order;


            //order = response.Order;
            //IOrder newOrder = OrderRulesFactory.Create(ChangeOrder.Add);

            //    response = newOrder.Update(order, order.OrderDate);


            //if(response.Success)
            //{
            //    _displayOrder.Show(order);


            //    Console.Write("Save this order (Y/N)? ");
            //    string saveOrder = Console.ReadLine().ToUpper();
            //    if (saveOrder == "Y")
            //    {
            //        _orderRepository.SaveOrder(order, order.OrderFileDate);
            //        Console.WriteLine();
            //        Console.WriteLine("Order saved!");
            //        response.Success = true;
            //    }
            //}
            return response;
        }


        public OrderResponse SaveOrder(Order order)
        {
            OrderResponse response = new OrderResponse();
            Console.Write("Save this order (Y/N)? ");
            string saveOrder = Console.ReadLine().ToUpper();
            if (saveOrder == "Y")
            {
                _orderRepository.SaveOrder(order, order.OrderFileDate);
                Console.WriteLine();
                Console.WriteLine("Order saved!");
                response.Success = true;
            }
            return response;
        }


        public OrderResponse EditOrder(DateTime date, int orderNumber)
        {
            OrderResponse response = new OrderResponse();
            Order order = new Order();
            //if (date > DateTime.Today)
            //{
            //    response.Success = false;
            //    response.Message = $"{date} is not valid.  Please enter a past date.";
            //    return response;
            //}

            if (orderNumber < 1)
            {
                response.Success = false;
                response.Message = "You must enter a valid order number!";
                return response;
            }

            else
            {
                response.Success = true;
            }


            OrderLookupResponse findOrderResponse = new OrderLookupResponse()
            {
                Order = _orderRepository.LoadOrder(date, orderNumber)
            };
            if (findOrderResponse.Order == null)
            {
                findOrderResponse.Success = false;
                findOrderResponse.Message = $"{orderNumber} is not a valid order number!";
            }
            else
            {
                findOrderResponse.Success = true;
            }

            if (findOrderResponse.Success)
            {
                order = findOrderResponse.Order;

                order.OrderFileDate = order.OrderDate.ToString("MMddyyyy");

                string editField = "To change value, edit here (to keep, press Enter): ";

                Console.WriteLine($"Customer Name: {order.CustomerName}");
                Console.Write(editField);
                string input = Console.ReadLine();
                if (input != "")
                {
                    order.CustomerName = input;
                }

                Console.WriteLine($"State Abbreviation: {order.State}");
                Console.Write(editField);
                input = Console.ReadLine();
                if (input != "")
                {
                    order.State = input.ToUpper();
                }


                ReadTaxData readTax = new ReadTaxData();
                //check state.txt
                readTax.InRepo(order.State);
                if (!readTax.InRepo(order.State))
                {
                    response.Message = "We do not sell in that state!";
                    return response;
                }

                else
                {
                    Tax stateTax = new Tax();
                    stateTax = readTax.StateTax(order.State);
                    order.TaxRate = (stateTax.TaxRate / 100);
                }

                Console.WriteLine($"Product: {order.ProductType}");
                Console.Write("Would you like to change your product? (Y/N): ");

                input = Console.ReadLine();
                if (input == "Y")
                {
                    Product newProduct = new Product();
                    //print list of products with foreach loop
                    FileProductRepository prodRepo = new FileProductRepository();
                    prodRepo.DisplayProducts();

                    //Console.Write("Enter a choice from the list above: ");
                    newProduct = prodRepo.ChooseProduct();
                    order.ProductType = newProduct.ProductType;
                    order.CostPerSquareFoot = newProduct.CostPerSquareFoot;
                    order.LaborCostPerSquareFoot = newProduct.LaborCostPerSquareFoot;
                }

                Console.WriteLine($"Order Area: {order.Area}");
                Console.Write(editField);
                input = Console.ReadLine();

                if (input != "")
                {
                    order.Area = -1;

                    while (order.Area < 100)
                    {
                        decimal orderArea;
                        if (decimal.TryParse(input, out orderArea))
                        {
                            order.Area = orderArea;
                        }


                        if (order.Area < 100)
                        {
                            Console.WriteLine($"Order Area: {order.Area}");
                            Console.Write(editField);
                            input = Console.ReadLine();
                        }
                    }
                }

                order.LaborCost = order.LaborCostPerSquareFoot * order.Area;
                order.MaterialCost = order.CostPerSquareFoot * order.Area;
                order.Tax = (order.LaborCost + order.MaterialCost) * order.TaxRate;
                order.Total = order.LaborCost + order.MaterialCost + order.Tax;

                response.Success = true;
                response.Order = order;

                //IOrder editOrder = OrderRulesFactory.Create(ChangeOrder.Edit);
                //Order foundOrder = new Order();
                //foundOrder = findOrderResponse.Order;


                //response = editOrder.Update(foundOrder, date);


                //if (response.Success)
                //{
                //    _displayOrder.Show(order);

                //    Console.Write("Save this order (Y/N)? ");
                //    string saveOrder = Console.ReadLine().ToUpper();
                //    if (saveOrder == "Y")
                //    {
                //        _orderRepository.SaveOrder(order, order.OrderFileDate);
                //        Console.WriteLine();
                //        Console.WriteLine("Order saved!");
                //        response.Success = true;
                //    }
                //}
            }
            return response;
        }

        public OrderResponse RemoveOrder(DateTime date, int orderNumber)
        {
            Order order = new Order();
            OrderResponse response = new OrderResponse();
            //if (date > DateTime.Today)
            //{
            //    response.Success = false;
            //    response.Message = $"{date} is not valid.  Please enter a past date.";
            //    return response;
            //}

            if (orderNumber < 1)
            {
                response.Success = false;
                response.Message = "You must enter a valid order number!";
                return response;
            }

            else
            {
                response.Success = true;
            }


            OrderLookupResponse findOrderResponse = new OrderLookupResponse();
            findOrderResponse.Order = _orderRepository.LoadOrder(date, orderNumber);

            if (findOrderResponse.Order == null)
            {
                findOrderResponse.Success = false;
                findOrderResponse.Message = $"{orderNumber} is not a valid order number!";
            }
            else
            {
                findOrderResponse.Success = true;
            }

            if (findOrderResponse.Success)
            {
                response.Order = findOrderResponse.Order;

                //IOrder removeOrder = OrderRulesFactory.Create(ChangeOrder.Remove);
                //Order foundOrder = new Order();
                //foundOrder = findOrderResponse.Order;

                //response = removeOrder.Update(foundOrder, date);


                //if (response.Success)
                //{
                //    _displayOrder.Show(order);


                //    Console.Write("Are you sure you want to cancel this order (Y/N)? ");
                //    string deleteOrder = Console.ReadLine().ToUpper();
                //    if (deleteOrder == "Y")
                //    {
                //        _orderRepository.DeleteOrder(order, order.OrderFileDate);
                //        Console.WriteLine();
                //        Console.WriteLine("Order cancelled!");
                //        response.Success = true;
                //    }
                //}
            }
            return response;
        }

        public OrderResponse DeleteOrder(Order order)
        {
            OrderResponse response = new OrderResponse();

            
            Console.Write("Are you sure you want to cancel this order (Y/N)? ");
            string deleteOrder = Console.ReadLine().ToUpper();
            if (deleteOrder == "Y")
            {
                _orderRepository.DeleteOrder(order, order.OrderFileDate);
                Console.WriteLine();
                Console.WriteLine("Order cancelled!");
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Nothing changed.";
            }

            return response;
        }
    }
}
