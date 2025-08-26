import "./App.css";
import Customers from "./Pages/Customers";
import Documents from "./Pages/Documents";
import NavBar from "./Components/NavBar";
import { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  const [page, setPage] = useState("Customers");
  return (
    <div className="container">
      <NavBar setPage={setPage} />
      {page === "Customers" && <Customers />}
      {page === "Documents" && <Documents />}
    </div>
  );
}

export default App;
