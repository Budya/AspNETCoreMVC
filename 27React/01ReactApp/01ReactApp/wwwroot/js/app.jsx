class Hello extends React.Component {
    render() {
        return <h1>HELLO, React.JS</h1>;
    }
}

ReactDOM.render(
    <Hello/>,
    document.getElementById("content")
);