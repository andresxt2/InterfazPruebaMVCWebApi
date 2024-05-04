
const contenedor = document.getElementById('cart-container');
const carritoVacioElement = document.getElementById('carrito-vacio');
const cantidadElement = document.getElementById("cantidad");
const precioElement = document.getElementById("precio");
const totalesContainer = document.getElementById('hidden-section');

function crearTarjetasProductos() {
    contenedor.innerHTML = "";
    const productos = JSON.parse(localStorage.getItem("semestres"));

    if (productos && productos.length > 0) {
        productos.forEach(producto => {
            const newShoe = document.createElement('article');
            newShoe.classList = "col-12";
            newShoe.innerHTML = `
            <section class="container border-bottom border-dark">
                <div class="row justify-content-center align-items-center mb-3 mt-3">
                    <div class="col-12 col-md-6 text-center">
                        <img src="${producto.foto}" alt="" class="imagen">
                    </div>
                    <div class="col-12 col-md-6 text-center mb-3">
                        <span class="text-center fw-bold p-5">${producto.nombre}</span>
                        <button type="button" class="bg-warning-subtle fw-bold" id="btnreducir">-</button>
                        <span class="text-center fw-bold precio-font p-3">$${producto.precio}</span>                    
                        <span class="p-2" id="cantidad-producto">${producto.cantidad}</span>
                    </div>
                </div>
            </section>`;

            contenedor.appendChild(newShoe);
            newShoe.getElementsByTagName("button")[0].addEventListener("click", (e) => {
                const cuentaElement = e.target.parentElement.getElementsByTagName("span")[2];
                cuentaElement.innerText = restarAlCarrito(producto);
                crearTarjetasProductos();
                actualizarTotales();
                revisarMensajeVacio();
            });
        });
    }
    revisarMensajeVacio();
    actualizarTotales();
}

function actualizarTotales() {
    const productos = JSON.parse(localStorage.getItem("semestres"));
    let cantidad = 0;
    let precio = 0;
    if (productos && productos.length > 0) {
        productos.forEach((producto) => {
            cantidad += producto.cantidad;
            precio += producto.precio * producto.cantidad;
        });
    }
    cantidadElement.innerText = cantidad;
    localStorage.setItem('precio', precio);
    precioElement.innerText = precio;
    if (precio === 0) {
        reiniciarCarrito();
        revisarMensajeVacio();
    }
}

function revisarMensajeVacio() {
    const productos = JSON.parse(localStorage.getItem("semestres"));
    carritoVacioElement.classList.toggle("escondido", productos);
    totalesContainer.classList.toggle("escondido", !(productos && productos.length > 0));
}

document.getElementById("reiniciar").addEventListener("click", () => {
    var resultado = confirm("¿Estás seguro de que deseas remover todos los items del carrito?");
    if (resultado) {
        contenedor.innerHTML = "";
        reiniciarCarrito();
        revisarMensajeVacio();
    }
});

crearTarjetasProductos();











