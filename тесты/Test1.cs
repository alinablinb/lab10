using ClassLibrary;
using ClassLibraryWeather;

namespace testt
{
    [TestClass]
    public sealed class WeatherTests
    {
        [TestMethod]
        public void TestTemperatureSetter()
        {
            var weather = new Weather();
            weather.Temperature = 25.0;
            Assert.AreEqual(25.0, weather.Temperature);
        }

        [TestMethod]
        public void TestHumiditySetter()
        {
            var weather = new Weather();
            weather.Humidity = 50;
            Assert.AreEqual(50, weather.Humidity);
        }

        [TestMethod]
        public void TestPressureSetter()
        {
            var weather = new Weather();
            weather.Pressure = 760;
            Assert.AreEqual(760, weather.Pressure);
        }

        [TestMethod]
        public void TestToString()
        {
            var weather = new Weather(25.0, 50, 760);
            string expected = "Температура: 25 °C, Влажность: 50 %, Давление: 760 мм рт. ст.";
            Assert.AreEqual(expected, weather.ToString());
        }

        [TestMethod]
        public void TestEquals()
        {
            var weather1 = new Weather(25.0, 50, 760);
            var weather2 = new Weather(25.0, 50, 760);
            Assert.IsTrue(weather1.Equals(weather2));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            var weather1 = new Weather(25.0, 50, 760);
            var weather2 = new Weather(25.0, 50, 760);
            Assert.AreEqual(weather1.GetHashCode(), weather2.GetHashCode());
        }

        [TestMethod]
        public void TestClone()
        {
            var weather = new Weather(25.0, 50, 760);
            var clonedWeather = (Weather)weather.Clone();
            Assert.AreEqual(weather.Temperature, clonedWeather.Temperature);
            Assert.AreEqual(weather.Humidity, clonedWeather.Humidity);
            Assert.AreEqual(weather.Pressure, clonedWeather.Pressure);
        }

        [TestMethod]
        public void TestWeatherCompareTo()
        {
            var weather1 = new Weather(20.0, 50, 760);
            var weather2 = new Weather(25.0, 50, 760);
            var weather3 = new Weather(20.0, 50, 760);

            Assert.IsTrue(weather1.CompareTo(weather2) < 0); // 20.0 < 25.0
            Assert.IsTrue(weather2.CompareTo(weather1) > 0); // 25.0 > 20.0
            Assert.IsTrue(weather1.CompareTo(weather3) == 0); // 20.0 == 20.0
        }

        [TestMethod]
        public void TestWeatherShallowCopy()
        {
            var weather = new Weather(25.0, 50, 760);
            var shallowCopy = weather.ShallowCopy();

            Assert.AreEqual(weather.Temperature, shallowCopy.Temperature);
            Assert.AreEqual(weather.Humidity, shallowCopy.Humidity);
            Assert.AreEqual(weather.Pressure, shallowCopy.Pressure);

            weather.Temperature = 30.0;
            Assert.AreEqual(30.0, weather.Temperature);
            Assert.AreEqual(25.0, shallowCopy.Temperature); // Shallow copy не должен измениться
        }

        [TestMethod]
        public void TestWeatherEqualsWithNull()
        {
            var weather = new Weather(25.0, 50, 760);
            Assert.IsFalse(weather.Equals(null));
        }

        [TestMethod]
        public void TestWeatherEqualsWithDifferentType()
        {
            var weather = new Weather(25.0, 50, 760);
            var otherObject = new object();
            Assert.IsFalse(weather.Equals(otherObject));
        }
    }
    [TestClass]
    public sealed class ControlElementTests
    {
        [TestMethod]
        public void TestIdSetter()
        {
            var controlElement = new ControlElement();
            controlElement.Id = 100;
            Assert.AreEqual(100, controlElement.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIdSetterOutOfRange()
        {
            var controlElement = new ControlElement();
            controlElement.Id = 2000; // Должно вызвать исключение
        }

        [TestMethod]
        public void TestXSetter()
        {
            var controlElement = new ControlElement();
            controlElement.X = 500;
            Assert.AreEqual(500, controlElement.X);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestXSetterOutOfRange()
        {
            var controlElement = new ControlElement();
            controlElement.X = 2000; // Должно вызвать исключение
        }

        [TestMethod]
        public void TestYSetter()
        {
            var controlElement = new ControlElement();
            controlElement.Y = 300;
            Assert.AreEqual(300, controlElement.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestYSetterOutOfRange()
        {
            var controlElement = new ControlElement();
            controlElement.Y = 2000; // Должно вызвать исключение
        }

        [TestMethod]
        public void TestShow()
        {
            var controlElement = new ControlElement(1, 100, 500, 300);
            string expected = "ID: 1, Id: 100, X: 500, Y: 300";
            Assert.AreEqual(expected, controlElement.Show());
        }

        [TestMethod]
        public void TestShowVirtual()
        {
            var controlElement = new ControlElement(1, 100, 500, 300);
            string expected = "ID: 1, Id: 100, X: 500, Y: 300";
            Assert.AreEqual(expected, controlElement.ShowVirtual());
        }

        [TestMethod]
        public void TestClone()
        {
            var controlElement = new ControlElement(1, 100, 500, 300);
            var clonedControlElement = (ControlElement)controlElement.Clone();
            Assert.AreEqual(controlElement.Id, clonedControlElement.Id);
            Assert.AreEqual(controlElement.X, clonedControlElement.X);
            Assert.AreEqual(controlElement.Y, clonedControlElement.Y);
        }

        [TestMethod]
        public void TestControlElementEqualsWithNull()
        {
            var controlElement = new ControlElement(1, 100, 500, 300);
            Assert.IsFalse(controlElement.Equals(null));
        }

        [TestMethod]
        public void TestControlElementEqualsWithDifferentType()
        {
            var controlElement = new ControlElement(1, 100, 500, 300);
            var otherObject = new object();
            Assert.IsFalse(controlElement.Equals(otherObject));
        }

        [TestMethod]
        public void TestControlElementCompareToWithNull()
        {
            var controlElement = new ControlElement(1, 100, 500, 300);
            Assert.AreEqual(-1, controlElement.CompareTo(null));
        }

        [TestMethod]
        public void TestControlElementToString()
        {
            var controlElement = new ControlElement(1, 100, 500, 300);
            string expected = "ID: 1, Id: 100, X: 500, Y: 300";
            Assert.AreEqual(expected, controlElement.ToString());
        }

        [TestMethod]
        public void TestControlElementRandomInit()
        {
            var controlElement = new ControlElement();
            controlElement.RandomInit();

            Assert.IsTrue(controlElement.Id >= 1 && controlElement.Id <= 1000);
            Assert.IsTrue(controlElement.X >= 0 && controlElement.X <= 1920);
            Assert.IsTrue(controlElement.Y >= 0 && controlElement.Y <= 1080);
        }

        [TestMethod]
        public void TestControlElementSortById()
        {
            var controlElements = new ControlElement[]
            {
            new ControlElement(1, 300, 500, 300),
            new ControlElement(2, 100, 500, 300),
            new ControlElement(3, 200, 500, 300)
            };

            Array.Sort(controlElements);

            Assert.AreEqual(100, controlElements[0].Id);
            Assert.AreEqual(200, controlElements[1].Id);
            Assert.AreEqual(300, controlElements[2].Id);
        }

        [TestMethod]
        public void TestControlElementSortByCoordinateX()
        {
            var controlElements = new ControlElement[]
            {
            new ControlElement(1, 100, 500, 300),
            new ControlElement(2, 200, 300, 300),
            new ControlElement(3, 300, 700, 300)
            };

            Array.Sort(controlElements, new SortByCoordinateX());

            Assert.AreEqual(300, controlElements[0].X);
            Assert.AreEqual(500, controlElements[1].X);
            Assert.AreEqual(700, controlElements[2].X);
        }

        [TestMethod]
        public void TestControlElementBinarySearchById()
        {
            var controlElements = new ControlElement[]
            {
            new ControlElement(1, 100, 500, 300),
            new ControlElement(2, 200, 500, 300),
            new ControlElement(3, 300, 500, 300)
            };

            Array.Sort(controlElements);

            var index = Array.BinarySearch(controlElements, new ControlElement(2, 200, 500, 300));

            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void TestControlElementBinarySearchByCoordinateX()
        {
            var controlElements = new ControlElement[]
            {
            new ControlElement(1, 100, 300, 300),
            new ControlElement(2, 200, 500, 300),
            new ControlElement(3, 300, 700, 300)
            };

            Array.Sort(controlElements, new SortByCoordinateX());

            var index = Array.BinarySearch(controlElements, new ControlElement(2, 200, 500, 300), new SortByCoordinateX());

            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void TestControlElementShallowCopy()
        {
            var original = new ControlElement(1, 100, 500, 300);
            var shallowCopy = (ControlElement)original.ShallowCopy();

            Assert.AreEqual(original.Id, shallowCopy.Id);
            Assert.AreEqual(original.X, shallowCopy.X);
            Assert.AreEqual(original.Y, shallowCopy.Y);

            original.Id = 200;
            Assert.AreEqual(200, original.Id);
            Assert.AreEqual(100, shallowCopy.Id); // Shallow copy не должен измениться
        }

        [TestMethod]
        public void TestControlElementDeepCopy()
        {
            var original = new ControlElement(1, 100, 500, 300);
            var deepCopy = (ControlElement)original.Clone();

            Assert.AreEqual(original.Id, deepCopy.Id);
            Assert.AreEqual(original.X, deepCopy.X);
            Assert.AreEqual(original.Y, deepCopy.Y);

            original.Id = 200;
            Assert.AreEqual(200, original.Id);
            Assert.AreEqual(100, deepCopy.Id); // Deep copy не должен измениться
        }
    }
    [TestClass]
    public sealed class ButtonTests
    {
        [TestMethod]
        public void TestTextSetter()
        {
            var button = new Button();
            button.Text = "Click Me";
            Assert.AreEqual("Click Me", button.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTextSetterEmpty()
        {
            var button = new Button();
            button.Text = ""; // Должно вызвать исключение
        }

        [TestMethod]
        public void TestShow()
        {
            var button = new Button(1, 100, 500, 300, "Click Me");
            string expected = "ID: 1, Id: 100, X: 500, Y: 300, Текст на кнопке: Click Me";
            Assert.AreEqual(expected, button.Show());
        }

        [TestMethod]
        public void TestShowVirtual()
        {
            var button = new Button(1, 100, 500, 300, "Click Me");
            string expected = "ID: 1, Id: 100, X: 500, Y: 300, Текст на кнопке: Click Me";
            Assert.AreEqual(expected, button.ShowVirtual());
        }

        [TestMethod]
        public void TestClone()
        {
            var button = new Button(1, 100, 500, 300, "Click Me");
            var clonedButton = (Button)button.Clone();
            Assert.AreEqual(button.Text, clonedButton.Text);
        }

        [TestMethod]
        public void TestButtonEqualsWithNull()
        {
            var button = new Button(1, 100, 500, 300, "Click Me");
            Assert.IsFalse(button.Equals(null));
        }

        [TestMethod]
        public void TestButtonEqualsWithDifferentType()
        {
            var button = new Button(1, 100, 500, 300, "Click Me");
            var otherObject = new object();
            Assert.IsFalse(button.Equals(otherObject));
        }

        [TestMethod]
        public void TestButtonInitWithInvalidText()
        {
            var button = new Button();
            Assert.ThrowsException<ArgumentException>(() => button.Text = "");
        }

        [TestMethod]
        public void TestButtonRandomInit()
        {
            var button = new Button();
            button.RandomInit();

            Assert.IsTrue(!string.IsNullOrEmpty(button.Text));
        }
    }
    [TestClass]
    public sealed class CheckboxButtonTests
    {
        [TestMethod]
        public void TestIsSelectedSetter()
        {
            var checkboxButton = new CheckboxButton();
            checkboxButton.IsSelected = true;
            Assert.IsTrue(checkboxButton.IsSelected);
        }

        [TestMethod]
        public void TestShow()
        {
            var checkboxButton = new CheckboxButton(1, 100, 500, 300, "мяу", true);
            string expected = "ID: 1, Id: 100, X: 500, Y: 300, Текст на кнопке: мяу, Выбрана: True";
            Assert.AreEqual(expected, checkboxButton.Show());
        }

        [TestMethod]
        public void TestShowVirtual()
        {
            var checkboxButton = new CheckboxButton(1, 100, 500, 300, "мяу", true);
            string expected = "ID: 1, Id: 100, X: 500, Y: 300, Текст на кнопке: мяу, Выбрана: True";
            Assert.AreEqual(expected, checkboxButton.ShowVirtual());
        }

        [TestMethod]
        public void TestClone()
        {
            var checkboxButton = new CheckboxButton(1, 100, 500, 300, "мяу", true);
            var clonedCheckboxButton = (CheckboxButton)checkboxButton.Clone();
            Assert.AreEqual(checkboxButton.IsSelected, clonedCheckboxButton.IsSelected);
        }

        [TestMethod]
        public void TestCheckboxButtonEqualsWithNull()
        {
            var checkboxButton = new CheckboxButton(1, 100, 500, 300, "мяу", true);
            Assert.IsFalse(checkboxButton.Equals(null));
        }

        [TestMethod]
        public void TestCheckboxButtonEqualsWithDifferentType()
        {
            var checkboxButton = new CheckboxButton(1, 100, 500, 300, "мяу", true);
            var otherObject = new object();
            Assert.IsFalse(checkboxButton.Equals(otherObject));
        }

        [TestMethod]
        public void TestCheckboxButtonInitWithInvalidText()
        {
            var checkboxButton = new CheckboxButton();
            Assert.ThrowsException<ArgumentException>(() => checkboxButton.Text = "");
        }

        [TestMethod]
        public void TestCheckboxButtonRandomInit()
        {
            var checkboxButton = new CheckboxButton();
            checkboxButton.RandomInit();

            Assert.IsTrue(!string.IsNullOrEmpty(checkboxButton.Text));
            Assert.IsTrue(checkboxButton.IsSelected == true || checkboxButton.IsSelected == false);
        }
    }
    [TestClass]
    public sealed class TextFieldTests
    {
        [TestMethod]
        public void TestHintSetter()
        {
            var textField = new TextField();
            textField.Hint = "введите свое имя";
            Assert.AreEqual("ввеите свое имя", textField.Hint);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHintSetterEmpty()
        {
            var textField = new TextField();
            textField.Hint = ""; // Должно вызвать исключение
        }

        [TestMethod]
        public void TestTextSetter()
        {
            var textField = new TextField();
            textField.Text = "Иван";
            Assert.AreEqual("Иван", textField.Text);
        }

        [TestMethod]
        public void TestShow()
        {
            var textField = new TextField(1, 100, 500, 300, "ввеите свое имя", "иван");
            string expected = "ID: 1, Id: 100, X: 500, Y: 300, Подсказка: ввеите свое имя, Текст: иван";
            Assert.AreEqual(expected, textField.Show());
        }

        [TestMethod]
        public void TestShowVirtual()
        {
            var textField = new TextField(1, 100, 500, 300, "ввеите свое имя", "иван");
            string expected = "ID: 1, Id: 100, X: 500, Y: 300, Подсказка: ввеите свое имя, Текст: иван";
            Assert.AreEqual(expected, textField.ShowVirtual());
        }

        [TestMethod]
        public void TestClone()
        {
            var textField = new TextField(1, 100, 500, 300, "ввеите свое имя", "иван");
            var clonedTextField = (TextField)textField.Clone();
            Assert.AreEqual(textField.Hint, clonedTextField.Hint);
            Assert.AreEqual(textField.Text, clonedTextField.Text);
        }

        [TestMethod]
        public void TestTextFieldEqualsWithNull()
        {
            var textField = new TextField(1, 100, 500, 300, "ввеите свое имя", "иван");
            Assert.IsFalse(textField.Equals(null));
        }

        [TestMethod]
        public void TestTextFieldEqualsWithDifferentType()
        {
            var textField = new TextField(1, 100, 500, 300, "ввеите свое имя", "иван");
            var otherObject = new object();
            Assert.IsFalse(textField.Equals(otherObject));
        }

        [TestMethod]
        public void TestTextFieldInitWithInvalidHint()
        {
            var textField = new TextField();
            Assert.ThrowsException<ArgumentException>(() => textField.Hint = "");
        }

        [TestMethod]
        public void TestTextFieldRandomInit()
        {
            var textField = new TextField();
            textField.RandomInit();

            Assert.IsTrue(!string.IsNullOrEmpty(textField.Hint));
            Assert.IsTrue(!string.IsNullOrEmpty(textField.Text));
        }
    }
    [TestClass]
    public sealed class IdNumberTests
    {
        [TestMethod]
        public void TestIdSetter()
        {
            var idNumber = new IdNumber(100);
            Assert.AreEqual(100, idNumber.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIdSetterNegative()
        {
            var idNumber = new IdNumber();
            idNumber.Id = -1; // Должно вызвать исключение
        }

        [TestMethod]
        public void TestToString()
        {
            var idNumber = new IdNumber(100);
            string expected = "100";
            Assert.AreEqual(expected, idNumber.ToString());
        }

        [TestMethod]
        public void TestEquals()
        {
            var idNumber1 = new IdNumber(100);
            var idNumber2 = new IdNumber(100);
            Assert.IsTrue(idNumber1.Equals(idNumber2));
        }

        [TestMethod]
        public void TestEqualsWithNull()
        {
            var idNumber = new IdNumber(100);
            Assert.IsFalse(idNumber.Equals(null));
        }

        [TestMethod]
        public void TestEqualsWithDifferentType()
        {
            var idNumber = new IdNumber(100);
            var otherObject = new object();
            Assert.IsFalse(idNumber.Equals(otherObject));
        }
    }
    [TestClass]
    public sealed class SortByCoordinateXTests
    {
        [TestMethod]
        public void TestCompareWithEqualX()
        {
            var sorter = new SortByCoordinateX();
            var controlElement1 = new ControlElement(1, 100, 500, 300);
            var controlElement2 = new ControlElement(2, 200, 500, 300);

            Assert.AreEqual(0, sorter.Compare(controlElement1, controlElement2));
        }

        [TestMethod]
        public void TestCompareWithDifferentX()
        {
            var sorter = new SortByCoordinateX();
            var controlElement1 = new ControlElement(1, 100, 300, 300);
            var controlElement2 = new ControlElement(2, 200, 500, 300);

            Assert.IsTrue(sorter.Compare(controlElement1, controlElement2) < 0); // 300 < 500
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCompareWithNull()
        {
            var sorter = new SortByCoordinateX();
            sorter.Compare(null, new ControlElement(1, 100, 500, 300));
        }
    }
}