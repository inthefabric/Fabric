
// GENERATED CODE
// Changes made to this source file will be overwritten

/*


--- VERTICES---

p (App)
p_na (Name)
p_nk (NameKey)
p_se (Secret)
p_od (OauthDomains)

a (Artifact)

c (Class)
c_na (Name)
c_nk (NameKey)
c_di (Disamb)
c_no (Note)

e (Email)
e_ad (Address)
e_co (Code)
e_ve (Verified)

f (Factor)
f_at (AssertionType)
f_de (IsDefining)
f_no (Note)
f_det (DescriptorType)
f_dit (DirectorType)
f_dip (DirectorPrimaryAction)
f_dir (DirectorRelatedAction)
f_evt (EventorType)
f_evd (EventorDateTime)
f_idt (IdentorType)
f_idv (IdentorValue)
f_lot (LocatorType)
f_lox (LocatorValueX)
f_loy (LocatorValueY)
f_loz (LocatorValueZ)
f_vet (VectorType)
f_veu (VectorUnit)
f_vep (VectorUnitPrefix)
f_vev (VectorValue)

i (Instance)
i_na (Name)
i_di (Disamb)
i_no (Note)

m (Member)
m_mt (MemberType)
m_osa (OauthScopeAllow)
m_ogr (OauthGrantRedirectUri)
m_ogc (OauthGrantCode)
m_oge (OauthGrantExpires)

oa (OauthAccess)
oa_to (Token)
oa_re (Refresh)
oa_ex (Expires)

r (Url)
r_na (Name)
r_fp (FullPath)

u (User)
u_na (Name)
u_nk (NameKey)
u_pa (Password)

v (Vertex)
v_id (VertexId)
v_ts (Timestamp)
v_t (VertexType)


--- EDGES ---

pdm (App-Defines-Member)
pdm_ts (Defines.Timestamp)
pdm_mt (Defines.MemberType)
pdm_ui (Defines.UserId)

acbm (Artifact-CreatedBy-Member)

apbf (Artifact-UsedAsPrimaryBy-Factor)
apbf_ts (UsedAsPrimaryBy.Timestamp)
apbf_dt (UsedAsPrimaryBy.DescriptorType)
apbf_ra (UsedAsPrimaryBy.RelatedArtifactId)

arbf (Artifact-UsedAsRelatedBy-Factor)
arbf_ts (UsedAsRelatedBy.Timestamp)
arbf_dt (UsedAsRelatedBy.DescriptorType)
arbf_pa (UsedAsRelatedBy.PrimaryArtifactId)

aue (Artifact-Uses-Email)

eba (Email-UsedBy-Artifact)

fcbm (Factor-CreatedBy-Member)

frpa (Factor-DescriptorRefinesPrimaryWith-Artifact)

frra (Factor-DescriptorRefinesRelatedWith-Artifact)

frta (Factor-DescriptorRefinesTypeWith-Artifact)

fpa (Factor-UsesPrimary-Artifact)

fra (Factor-UsesRelated-Artifact)

faa (Factor-VectorUsesAxis-Artifact)

maboa (Member-AuthenticatedBy-OauthAccess)
maboa_ts (AuthenticatedBy.Timestamp)

mca (Member-Creates-Artifact)
mca_ts (Creates.Timestamp)
mca_vt (Creates.VertexType)

mcf (Member-Creates-Factor)
mcf_ts (Creates.Timestamp)
mcf_dt (Creates.DescriptorType)
mcf_pa (Creates.PrimaryArtifactId)
mcf_ra (Creates.RelatedArtifactId)

mdbp (Member-DefinedBy-App)

mdbu (Member-DefinedBy-User)

oaam (OauthAccess-Authenticates-Member)

udm (User-Defines-Member)
udm_ts (Defines.Timestamp)
udm_mt (Defines.MemberType)
udm_pi (Defines.AppId)

*/