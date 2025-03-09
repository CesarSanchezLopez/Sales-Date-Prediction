document.getElementById('generateChart').addEventListener('click', function() {
    // Obtener los datos de la caja de texto
    let inputData = document.getElementById('dataInput').value;

    // Convertir la entrada en un arreglo de números
    let data = inputData.split(',').map(item => parseInt(item.trim()));

    // Si los datos no son válidos, mostrar un mensaje
    if (data.some(isNaN)) {
        alert('Por favor, ingrese datos válidos (números separados por comas).');
        return;
    }

    // Establecer el tamaño del gráfico
    let width = 500;
    let height = 300;
    let margin = { top: 20, right: 30, bottom: 40, left: 40 };

    // Limpiar el contenedor del gráfico antes de crear uno nuevo
    document.getElementById('chartContainer').innerHTML = '';

    // Crear el contenedor SVG para el gráfico
    let svg = d3.select('#chartContainer')
        .append('svg')
        .attr('width', width)
        .attr('height', height);

    // Definir las escalas
    let x = d3.scaleLinear()  // Usamos scaleLinear para el eje X (horizontal)
        .domain([0, d3.max(data)])
        .nice()
        .range([margin.left, width - margin.right]);

    let y = d3.scaleBand()  // Usamos scaleBand para el eje Y (vertical)
        .domain(d3.range(data.length))
        .range([margin.top, height - margin.bottom])
        .padding(0.1);

    // Crear las barras del gráfico y asignarles colores diferentes
    svg.selectAll('.bar')
        .data(data)
        .enter().append('rect')
        .attr('class', 'bar')
        .attr('x', margin.left)
        .attr('y', (d, i) => y(i))
        .attr('width', d => x(d) - margin.left)  // El ancho de la barra será el valor de X
        .attr('height', y.bandwidth())
        .attr('fill', (d, i) => {
            // Asignar un color a cada barra, puedes usar una escala de colores
            // Aquí estamos usando colores diferentes según el índice de la barra
            const colors = ['#FF6347', '#4682B4', '#32CD32', '#FFD700', '#8A2BE2'];
            return colors[i % colors.length];  // Si hay más barras que colores, vuelve a empezar
        });

    // Añadir las etiquetas del eje Y (nombres de las barras)
    svg.append('g')
        .selectAll('.tick')
        .data(data)
        .enter().append('text')
        .attr('class', 'axis-label')
        .attr('x', margin.left - 10)
        .attr('y', (d, i) => y(i) + y.bandwidth() / 2)
        .attr('dy', '.35em')  // Alinear verticalmente
        .text((d, i) => `Item ${i + 1}`);  // Etiquetas con el índice

    // Añadir el eje X
    svg.append('g')
        .attr('class', 'axis')
        .attr('transform', `translate(0, ${height - margin.bottom})`)
        .call(d3.axisBottom(x));

    // Añadir el eje Y
    svg.append('g')
        .attr('class', 'axis')
        .attr('transform', `translate(${margin.left}, 0)`)
        .call(d3.axisLeft(y));
});