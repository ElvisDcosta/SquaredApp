import { useState } from "react";

type Props = {
  setPage: (page: string) => void;
};

const NavBar = ({ setPage }: Props) => {
  const [accounts, setAccounts] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);

  const GetCustomers = async () => {
    setLoading(true);
    try {
      const res = await fetch(
        "http://localhost:5001/api/GetCustomerData/customers"
      );
      const data = await res.json();
      setAccounts(data);
    } catch (err) {
      console.error("Error fetching Salesforce customers:", err);
    } finally {
      setLoading(false);
    }
  };
  return (
    <nav className="navbar navbar-expand-lg bg-body-tertiary">
      <div className="container-fluid">
        <a className="navbar-brand" href="#">
          Squared Group
        </a>
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <ul className="navbar-nav me-auto mb-2 mb-lg-0">
            <li className="nav-item" onClick={() => setPage("Customers")}>
              <a
                className="nav-link active"
                aria-current="page"
                href="#"
                onClick={GetCustomers}
              >
                Customers
              </a>
            </li>
            <li className="nav-item" onClick={() => setPage("Documents")}>
              <a className="nav-link active" aria-current="page" href="#">
                Documents
              </a>
            </li>
          </ul>
          <form className="d-flex" role="search">
            <input
              className="form-control me-2"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />
            <button className="btn btn-outline-success" type="submit">
              Search
            </button>
          </form>
        </div>
      </div>
    </nav>
  );
};

export default NavBar;
