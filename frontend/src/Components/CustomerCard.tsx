import React from "react";

type Props = {};

const CustomerCard = (props: Props) => {
  return (
    <div className="d-grid gap-2 d-md-flex justify-content-md-end">
      {" "}
      <div
        style={{
          display: "flex",
          gap: "10px",
          padding: "10px",
        }}
      >
        <input
          type="text"
          id="Group1"
          placeholder="Customer ID"
          style={{ width: "350px" }}
        ></input>
        <input
          type="text"
          id="Group1"
          placeholder="Customer Name"
          style={{ width: "350px" }}
        ></input>
        <input
          type="text"
          id="Group1"
          placeholder="Earlieast Expiring
        Document"
          style={{ width: "350px" }}
        ></input>
      </div>
      <div
        className="d-grid gap-2 d-md-flex justify-content-md-end"
        style={{
          display: "flex",
          gap: "10px",
          padding: "10px",
        }}
      >
        <button type="button" className="btn btn-info me-md-2">
          Update
        </button>
        <button type="button" className="btn btn-danger me-md-2">
          Delete
        </button>
      </div>
    </div>
  );
};

export default CustomerCard;
