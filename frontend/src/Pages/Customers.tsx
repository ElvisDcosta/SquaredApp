import React from "react";
import CustomerCard from "../Components/CustomerCard";

type Props = {};

const Customers = (props: Props) => {
  return (
    <div className="d-grid gap-4">
      <CustomerCard></CustomerCard>
      <div className="d-grid gap-2 d-md-flex justify-content-md-end">
        <button className="btn btn-primary me-md-2" type="button">
          Add Customer
        </button>
      </div>
    </div>
  );
};

export default Customers;
