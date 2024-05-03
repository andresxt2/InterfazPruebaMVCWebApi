document.getElementById("comprar").addEventListener("click", () => {
    var resultado = confirm("¿Estás seguro de que deseas comprar los productos en el carrito?");
    if (resultado) {
        // Obtener los datos del carrito del localStorage
        const zapatosData = localStorage.getItem("semestres");
        const subtotalData = localStorage.getItem("precio");

        // Enviar los datos al controlador Cart usando fetch
        fetch('@Url.Action("GuardarCompra", "Cart")', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                ZapatosData: zapatosData,
                SubtotalData: subtotalData
            })
        })
            .then(response => response.json())
            .then(data => {
                // Manejar la respuesta del servidor si es necesario
                console.log(data);
                // Redirigir a donde quieras después de procesar la compra
                window.location.href = '@Url.Action("Index", "Home")'; // Por ejemplo, redirige a la página de inicio
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
});
