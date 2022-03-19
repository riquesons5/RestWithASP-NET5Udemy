using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace RestWithASPNET.Calculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            try
            {
                var result = Operator(EnumOperator.sum, firstNumber, secondNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            try
            {
                var result = Operator(EnumOperator.subtraction, firstNumber, secondNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            try
            {
                var result = Operator(EnumOperator.multiplication, firstNumber, secondNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            try
            {
                var result = Operator(EnumOperator.division, firstNumber, secondNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            try
            {
                var result = Operator(EnumOperator.mean, firstNumber, secondNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            try
            {
                var result = Operator(EnumOperator.squareRoot, firstNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region rules
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        private string Operator(EnumOperator operationType, params string[] numbers)
        {
            foreach (string number in numbers)
            {
                if (!IsNumeric(number)) throw new Exception("Operador inválido!");
            }

            switch (operationType)
            {
                case EnumOperator.sum:
                    return (ConvertToDecimal(numbers[0]) + ConvertToDecimal(numbers[1])).ToString();
                case EnumOperator.subtraction:
                    return (ConvertToDecimal(numbers[0]) - ConvertToDecimal(numbers[1])).ToString();
                case EnumOperator.multiplication:
                    return (ConvertToDecimal(numbers[0]) * ConvertToDecimal(numbers[1])).ToString();
                case EnumOperator.division:
                    return (ConvertToDecimal(numbers[0]) / ConvertToDecimal(numbers[1])).ToString();
                case EnumOperator.mean:
                    return ((ConvertToDecimal(numbers[0]) + ConvertToDecimal(numbers[1])) / 2).ToString();
                case EnumOperator.squareRoot:
                    return (Math.Sqrt((double)ConvertToDecimal(numbers[0]))).ToString();
                default:
                    throw new Exception("Operação inválida!");
            }
        }
        #endregion
    }

    public enum EnumOperator
    {
        sum = 1,
        subtraction = 2,
        multiplication = 3,
        division = 4,
        mean = 6,
        squareRoot = 7
    }
}
