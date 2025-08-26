import React from "react";
import DocumentCard from "../Components/DocumentCard";

type Props = {};

const Documents = (props: Props) => {
  return (
    <div className="d-grid gap-4">
      <DocumentCard></DocumentCard>
      <div className="d-grid gap-2 d-md-flex justify-content-md-end">
        <button className="btn btn-primary me-md-2" type="button">
          Add Document
        </button>
      </div>
    </div>
  );
};

export default Documents;
